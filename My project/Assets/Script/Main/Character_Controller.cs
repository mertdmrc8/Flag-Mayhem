using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;

public class Character_Controller : MonoBehaviourPun
{
 
    public Animator anim;
    Rigidbody2D rb;
    public float speed = 7f;
    public float jumpSpeed = 5f;
    private float direction = 0f;
    public GameObject flag; 
    private bool isTouchingGround;
    float groundcheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck; 
    public TeamManager Team;
 
    public string nickname;

    public PlayersController PlayerController;

    [HideInInspector] public bool isFacingRight = true;

    PhotonView pw;




    void Awake(){
        pw = GetComponent<PhotonView>();
        PlayerController=GameObject.Find("PlayerController").GetComponent<PlayersController>();
        PlayerController.photonViews.Add(pw);
    }
    void Start()
    {
        //bütün photon viewlere  odadaki bütün bilgiler gider  
       
       if (pw.IsMine  )
        {
            rb = GetComponent<Rigidbody2D>();
            anim.SetBool("isWalking", false);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
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
