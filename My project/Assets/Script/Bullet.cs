using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class Bullet : MonoBehaviourPun
{
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    PhotonView pw_b;

    Health _health;
    int _currentHealth;
    GameObject player;
    


    private void Start()
    {
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        
        pw_b = GetComponent<PhotonView>();
        Debug.Log(_health.localHealth);

        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {

        rb.velocity = transform.right * bulletSpeed;
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision== player)
        {
            if (pw_b.IsMine)
            {
                
                _health.localHealth--;
                Debug.Log("local " + _health.localHealth);
            }
           
           

        }
        else
        {
            
            _health.enemyHealth--;
            Debug.Log("guest" + _health.enemyHealth);
        }

        Destroy(gameObject);

    }

   
  

}
