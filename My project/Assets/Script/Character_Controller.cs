using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;

public class Character_Controller : MonoBehaviourPun, IPunObservable
{
    public Animator anim;
    Rigidbody2D rb;


    public float speed = 7f;
    public float jumpSpeed = 5f;
    private float direction = 0f;



    private bool isTouchingGround;
    float groundcheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;



    [HideInInspector] public bool isFacingRight = true;

    PhotonView pw;




    void Start()
    {

        pw = GetComponent<PhotonView>();
        //bütün photon viewlere  odadaki bütün bilgiler gider 

        if (pw.IsMine == false)
        {
            GetComponent<SpriteRenderer>().color = Color.red;

        }
        else if (GetComponent<PhotonView>().IsMine == true)
        {
            rb = GetComponent<Rigidbody2D>();
            anim.SetBool("isWalking", false);

        }



    }

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
    private void FixedUpdate()
    {

    }

    void Dead()
    {
        Debug.Log("�ld�n");
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting)
        //{
        //    stream.SendNext(transform.position);
        //    stream.SendNext(transform.rotation);
        //}
        //else if (stream.IsReading)
        //{
        //    transform.position = (Vector3)stream.ReceiveNext();
        //    transform.rotation = (Quaternion)stream.ReceiveNext();
        //}
    }
}
