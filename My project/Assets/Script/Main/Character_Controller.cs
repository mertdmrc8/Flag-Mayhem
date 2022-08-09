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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        if (bullet != null && bullet.ordinary != this.gameObject)
        { 
            print("merminin carptığı karakter ");
            print("takım ismi " + Team.name);
            Destroy(bullet.gameObject);

            health -= 50; 

        }
    }

    // Update is called once per frame
    void Update()
    {

        Team.healthbar.fillAmount = health / 100f;

        if (health <= 0)
        {     print(Team.name+"health 0 ");
            if (flag != null)
            { 
                flag.transform.SetParent(flag.flagbase.transform);
                flag = null;
                print(Team.name+" bayrak ayarlandi ");
                // flag.transform.position = flagbase.transform.position;
            }
            // print(this.gameObject.name + " , " + Team.Base_.gameObject.name);
            Team.PlayerSetBase(this.transform.GetComponent<Character_Controller>());
            
        }

        //Movement
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
