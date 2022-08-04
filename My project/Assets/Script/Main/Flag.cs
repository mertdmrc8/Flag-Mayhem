using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Flag : MonoBehaviour
{
    PhotonView pw;
    public  Character_Controller player ;
 

    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = null;
        if (collision.tag == "Player")
        {
            Player = collision.gameObject;
            
            GameObject Flag = GameObject.Find("Flag");
        
            this.transform.parent = Player.transform;
            player=Player.GetComponent<Character_Controller>();
        }

    }
}
