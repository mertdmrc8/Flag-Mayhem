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
    CharacterController cc;


    private void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        pw_b = GetComponent<PhotonView>();
    }
    private void FixedUpdate()
    {
      
            rb.velocity = transform.right * bulletSpeed;
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.tag=="Player")
        {
            Debug.Log("aha kafasýna geldi");
        }
    }

}
