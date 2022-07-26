using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Flag : MonoBehaviourPun,IPunObservable
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
        else if (collision.tag == "BlueHouse")
        {
            Destroy(gameObject);
            Debug.Log("maviye 1 yaz");

        }
        else if (collision.tag == "RedHouse")
        {
            Destroy(gameObject);
            Debug.Log("kýrmýzýya 1 yaz");
        }
        if (collision.tag=="Bullet")
        {
            this.transform.parent = null;
        }


    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //if (stream.IsWriting)
        //{
        //    stream.SendNext(transform.position);
           
        //}
        //else if (stream.IsReading)
        //{
        //    transform.position = (Vector3)stream.ReceiveNext();
            
        //}
    }
}
