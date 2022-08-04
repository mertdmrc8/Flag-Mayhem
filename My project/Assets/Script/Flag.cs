using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Flag : MonoBehaviourPun, IPunObservable
{

    GameObject mng;
    GameObject _player;
    GameObject Enemy;
    GameObject endGame;
    TextMesh gameScore;
    GameObject flagHandle;

    private void Start()
    {
        mng = GameObject.Find("Manager");
        _player = GameObject.FindGameObjectWithTag("Player");
      

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = null;

        if (collision.tag == "Player")
        {
            Player = collision.gameObject;

            this.transform.parent = Player.transform;
            this.transform.position = new Vector3(0, 3, 0);                       
        }

        else if (collision.tag == "BlueHouse")
        {
            mng.GetComponent<Manager>().Score++;
            GetComponent<PhotonView>().RPC("TakeFlag", RpcTarget.All, null);

            Debug.Log(mng.GetComponent<Manager>().Score + ":" + mng.GetComponent<Manager>().opScore);
           
            

        }

        else if (collision.tag == "RedHouse")
        {
            mng.GetComponent<Manager>().opScore++;

            GetComponent<PhotonView>().RPC("TakeFlag", RpcTarget.All, null);

            //transform.parent = null;
            //transform.position = new Vector3(0, 3f, 0);
            //_player.GetComponent<Health>().Respawn();


            Debug.Log(mng.GetComponent<Manager>().Score + ":" + mng.GetComponent<Manager>().opScore);
           
           
            
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);


        }
        else if (stream.IsReading)
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
           

        }

    }
    [PunRPC]
    private void TakeFlag()
    {
        transform.parent = null;
        transform.position = new Vector3(0, 3f, 0);
        _player.GetComponent<Health>().Respawn();
    }

    

}
