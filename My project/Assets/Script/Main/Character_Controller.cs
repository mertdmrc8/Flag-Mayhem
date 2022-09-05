using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviourPun
{
    public Animator anim;
    Rigidbody2D rb;
    public float speed = 7f;
    public float jumpSpeed = 5f;
    private float direction = 0f;
    public Flag flag;
    private bool isTouchingGround;
    float groundcheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;
    public TeamManager Team;

    public int health = 100;

    public Players_Controller PlayerController;
    public ConsoleManager Console;

    [HideInInspector] public bool isFacingRight = true;

    PhotonView pw;
    public int flagscore = 0;

    public Timer timer;

    private GameObject Ordinary_go;
    private Image bar;
    public Text Nickname;

    public bool unlimitedhealth = false;

    void Awake()
    {

        print("local nick " + PlayerProperties.nickname_);

        Console = GameObject.Find("ButtonController").GetComponent<ConsoleManager>();
        pw = GetComponent<PhotonView>();
        PlayerController = GameObject.Find("PlayerController").GetComponent<Players_Controller>();
        this.gameObject.GetComponent<PhotonView>().RPC("addlist", RpcTarget.All, null);
        this.gameObject.transform.parent = PlayerController.transform;
        GameObject healthbar = this.gameObject.transform.Find("Canvas").gameObject.transform.Find("healthbar").gameObject;
        bar = healthbar.transform.Find("bar_").GetComponent<Image>();
        float R = UnityEngine.Random.Range(0, 226 / 255f);
        float G = UnityEngine.Random.Range(0, 226 / 255f);
        float B = UnityEngine.Random.Range(0, 226 / 255f);
        Color ColorToBeGenerate = new Color(R, G, B);
        bar.color = ColorToBeGenerate;
        // print(new Color((float)UnityEngine.Random.Range(0, 255), (float)UnityEngine.Random.Range(0, 255), (float)UnityEngine.Random.Range(0, 255)));
        Nickname = this.gameObject.transform.Find("Canvas").gameObject.transform.Find("NickName").gameObject.GetComponent<Text>();





    }
    void Start()
    {
        //bütün photon viewlere  odadaki bütün bilgiler gider  

        PlayerController.AddPlayerCountInScene();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        if (pw.IsMine)
        {
            rb = GetComponent<Rigidbody2D>();
            anim.SetBool("isWalking", false);
            timer.thisplayer = this.transform.gameObject;
        }

        if (pw.IsMine)
        {

            object[] obj = { pw.ViewID, PlayerProperties.nickname_ };
            transform.gameObject.GetComponent<PhotonView>().RPC("setnick", RpcTarget.All, obj);

        }
    }

    [PunRPC]
    private void setnick(object[] data)
    {
        //pw is mine olmıyacak???
        int ordinary_id = Convert.ToInt32(data[0]);
        string nick = Convert.ToString(data[1]);
        if (ordinary_id == pw.ViewID)
        {
            Nickname.text = nick;
        }


    }


    [PunRPC]
    public void addlist()
    {

        PlayerController.photonviewlist.Add(this.transform.GetComponent<PhotonView>());
    }



    [PunRPC]
    private void SetTeam()
    {

        TeamManager CurrentTeam = PlayerController.getCurrentTeam();

        this.transform.parent = CurrentTeam.transform;

        this.transform.position = CurrentTeam.Base_.transform.position;

        this.GetComponent<Character_Controller>().Team = CurrentTeam;
        print(Team.name + "den üretildi");
        CurrentTeam.team_players.Add(this.GetComponent<Character_Controller>());
        this.transform.GetComponent<SpriteRenderer>().color = CurrentTeam.Color.color;


    }

    IEnumerator waitflag()
    {
        print(Team.name + " bayrak ayarlandi ");
        flag.enabled = false;
        yield return new WaitForSeconds(1);
        flag.enabled = true;

    }
    //burda değil karşıda doru çalışıyor 



    //rpc her 2 yerde de çağırılır 
    //karşıdaki kendi görüntüsünde çağırıyor
    //yani ölen kişi
    [PunRPC]
    public void FindKiller(int killer_id)
    {
        if (pw.IsMine)
        {


            if (this.transform.gameObject.GetComponent<PhotonView>().ViewID == killer_id)
            {
                PlayerProperties.score_ += 100;
                PlayerProperties.kill_ += 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null && bullet.team != this.Team)
        {
            health -= 34;
            if (health <= 0)
            {
                //BURASI RPC OLMALI MI?
                print(Team.name + "health 0 ");
                if (flag != null)
                {
                    print("bayrak " + Team.name + "di");

                    flag.transform.parent = flag.flagbase.transform;
                    flag.transform.position = flag.flagbase.transform.position;
                    flag.player = null;
                    flag = null;
                }
                // print(this.gameObject.name + " , " + Team.Base_.gameObject.name);

                if (pw.IsMine)
                {

                    PlayerProperties.death_++;
                    print("bullet :" + bullet.incoming_id);
                    //rpc gereksiz olabilr karşıdaki istemciden bir şey çalışsın isteniyor ama sadece ölenlerde çalışıyor 
                    // o kişiyi bulup rpcsini çalıştırmak daha doru 
                    PhotonNetwork.GetPhotonView(bullet.incoming_id).RPC("FindKiller", RpcTarget.All, bullet.incoming_id);
                    //   transform.GetComponent<PhotonView>().RPC("FindKiller", RpcTarget.All, bullet.incoming_id);
                    //bu id den kişiyi bul ozmn 
                    //bulunan kişinn sadece localinde çalıştırmak istiyosam ?? RPC içine ismine mı ? 
                    Team.GetComponent<PhotonView>().RPC("PlayerSetBase", RpcTarget.All, pw.ViewID);
                }
            }
            Destroy(bullet.gameObject);
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (Team != null)
        {

            bar.fillAmount = health / 100f;
        }

        //Moveme
        if (Console.isactive)
        {
            if (Console.code == "health")
            {
                print("health");
                this.gameObject.GetComponent<PhotonView>().RPC("hackhealth", RpcTarget.All, pw.ViewID);
                // unlimitedhealth = true;
                Console.code = "";

            }
            if (Console.code == "health*")
            {
                this.gameObject.GetComponent<PhotonView>().RPC("hack_health", RpcTarget.All, pw.ViewID);
                // unlimitedhealth = false;
                Console.code = "";
            }
            if (Console.code == "bullet")
            {
                transform.GetComponent<playerShoot>().fireRate = 0.1f;
                Console.code = "";
            }
            if (Console.code == "bullet*")
            {
                transform.GetComponent<playerShoot>().fireRate = 0.2f;
                Console.code = "";
            }

        }
        if (unlimitedhealth)
        {
            health = 100;
        }


        if (pw.IsMine)
        {

            isTouchingGround = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);

            Movement();

            //Animation

            if (direction < 0f || direction > 0f)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
            if (!isTouchingGround)
            {
                anim.SetBool("isWalking", false);
            }

        }
        if (isTouchingGround)
        {
            anim.SetBool("isGrounded", true);
            anim.SetBool("isJump", false);
        }
        else
        {
            anim.SetBool("isGrounded", false);
        }

    }


    [PunRPC]
    public void hackhealth(int id)
    {

        unlimitedhealth = true;

    }

    [PunRPC]
    public void hack_health(int id)
    {

        unlimitedhealth = false;

    }

    private void Movement()
    {
        direction = Input.GetAxisRaw("Horizontal");


        if (direction > 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
            isFacingRight = true;


        }
        else if (direction < 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
            isFacingRight = false;

        }

        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);

        }




        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            anim.SetBool("isJump", true);
        }
    }


}
