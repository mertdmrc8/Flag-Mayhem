using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    PhotonView pw_b;


    private void Start()
    {

        pw_b = GetComponent<PhotonView>();
    }
    private void FixedUpdate()
    {
      
            rb.velocity = transform.right * bulletSpeed;
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
       


    }

}
