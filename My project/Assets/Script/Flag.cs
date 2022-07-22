using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Flag : MonoBehaviour
{
    PhotonView pw;
    

    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = null;
        if (collision.tag == "Player")
        {
            Player = collision.gameObject;
              
            this.transform.parent = Player.transform;

        }
        else if (collision.tag == "House")
        {
            Destroy(gameObject);
            Debug.Log("asfas");

        }
        

    }
    
}
