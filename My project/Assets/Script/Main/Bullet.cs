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

    public GameObject ordinary;


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
    public IEnumerator DestroyBullet()
    {

        ordinary = this.gameObject;
        //burda atıyor karşıda nasıl atama yapıcak 
        print(ordinary);
        yield return new WaitForSeconds(0.5f);
        try
        {
            Destroy(gameObject);
            print("destroy with corretine");

        }
        catch
        {
            print("destroy catch");

        }
    }

}
