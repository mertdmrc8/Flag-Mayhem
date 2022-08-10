using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviourPun
{

    public int roomid_;
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
    public string nickname;

    private bool health_bool = true;

    public PlayersController PlayerController;

    [HideInInspector] public bool isFacingRight = true;

    PhotonView pw;

    private bool triggerbool = true;


    void Awake()
    {
        pw = GetComponent<PhotonView>();
        PlayerController = GameObject.Find("PlayerController").GetComponent<PlayersController>();
        PlayerController.photonViews.Add(pw);
    }
    void Start()
    {
        //bütün photon viewlere  odadaki bütün bilgiler gider  

        if (pw.IsMine)
        {
            rb = GetComponent<Rigidbody2D>();
            anim.SetBool("isWalking", false);
        }


    }


    IEnumerator waitflag()
    {


        print(Team.name + " bayrak ayarlandi ");
        flag.enabled = false;
        yield return new WaitForSeconds(1);
        flag.enabled = true;

    }
    //burda değil karşıda doru çalışıyor 


    [PunRPC]
    //rpc her 2 yerde de çağırılır 
    //karşıdaki kendi görüntüsünde çağırıyor
    //yani ölen kişi
    public void FindKiller(int killer_id)
    {
        print("find killer :::" + Team.name);

        print("view id " + this.transform.gameObject.GetComponent<PhotonView>().ViewID);
        print("killerid  " + killer_id);

        if (this.transform.gameObject.GetComponent<PhotonView>().ViewID == killer_id)
        {
            //2 ıere dönüyor niye
            print(" killer" + Team.name);
            this.transform.GetComponent<PlayerDatabase>().UpdateAndAddData(0, 0, 1);


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null && bullet.ordinary != this.gameObject)
        {
            health -= 50;
            if (health <= 0)
            {
                //BURASI RPC OLMALI MI?
                PlayerProperties.death_++;
                print(Team.name + "health 0 ");
                if (flag != null)
                {
                    print("bayrak " + Team.name + "di");
                    flag.transform.parent = flag.flagbase.transform;
                    flag.transform.position = flag.flagbase.transform.position;
                    flag = null;
                }
                // print(this.gameObject.name + " , " + Team.Base_.gameObject.name);

                if (pw.IsMine)
                {
                    print("bullet :" + bullet.incoming_id);
                    transform.GetComponent<PhotonView>().RPC("FindKiller", RpcTarget.All, bullet.ordinary.GetComponent<PhotonView>().ViewID);
                    Team.PlayerSetBase(this.transform.GetComponent<Character_Controller>());
                }
                health = 100;
            }
            Destroy(bullet.gameObject);
        }
    }

    // Update is called once per frame

    void Update()
    {
        if (Team != null)
        {

            Team.healthbar.fillAmount = health / 100f;
        }

        if (health <= 0 && health_bool)
        {


        }
        //Movement

        if (pw.IsMine)//karşıda da burda da karşı clientler çalışmaz
                      //karşıda da burda da bu kod o nesnede çalışır 
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


        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }
    }


}
