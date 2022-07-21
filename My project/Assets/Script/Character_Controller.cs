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
    private Vector2 smootMove;

    private GameObject  playerCamera;
    private GameObject sceneCamera;
    private bool isTouchingGround;
    float groundcheckRadius = 0.1f;
    public LayerMask groundLayer;
    public Transform groundcheck;

    [HideInInspector] public bool isFacingRight = true;

    PhotonView pw;
    void Start()
    {

        sceneCamera = GameObject.Find("Main Camera");
        playerCamera = GameObject.Find("PlayerCamera");

        pw = GetComponent<PhotonView>();


        if (pw.IsMine == false)
        {

            GetComponent<SpriteRenderer>().color = Color.red;


        }
        else if (GetComponent<PhotonView>().IsMine == true)
        {
            rb = GetComponent<Rigidbody2D>();
            anim.SetBool("isWalking", false);

        }

        //if (pw.IsMine)
        //{
        //    sceneCamera.SetActive(false);
        //    playerCamera.SetActive(true);
        //}


    }

    // Update is called once per frame
    void Update()
    {
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
        else if (!pw.IsMine)
        {
            SmoothMovement();
        }
    }

    private void SmoothMovement()
    {
        transform.position = Vector2.Lerp(transform.position, smootMove, Time.deltaTime * 10);
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
        Debug.Log(direction);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else if (stream.IsReading)
        {
            smootMove = (Vector2)stream.ReceiveNext();
        }
    }
}
