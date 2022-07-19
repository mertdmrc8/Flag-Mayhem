using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class Character_Controller : MonoBehaviour
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

    PhotonView pw;
    void Start()
    {


        pw=GetComponent<PhotonView>();


        if (pw.IsMine == false)
        {
            
            GetComponent<SpriteRenderer>().color = Color.red;


        }
        else if (pw.IsMine)
        {
            rb=GetComponent<Rigidbody2D>();
            anim.SetBool("isWalking", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pw.IsMine)
        {
            isTouchingGround = Physics2D.OverlapCircle(groundcheck.position, groundcheckRadius, groundLayer);
            direction = Input.GetAxis("Horizontal");
            Movement();
            
        }
    }
    private void Movement()
    {
        if (direction > 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
            anim.SetBool("isWalking", true);
        }
        else if (direction < 0f)
        {
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
            transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
            anim.SetBool("isWalking", true);
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
}
