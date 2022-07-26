using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Flag : MonoBehaviourPun, IPunObservable
{
    PhotonView pw;
    GameObject mng;
    
    int score = 0;
    int opScore = 0;

    GameObject _player;
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

            transform.position = new Vector3(0, 1, 0);
        }
        else if (collision.tag == "BlueHouse")
        {
            transform.parent = null;
            Destroy(gameObject);
            Destroy(_player);

            score++;
            Debug.Log(score + ":" + opScore);
            mng.GetComponent<Manager>().Restart();


        }
        else if (collision.tag == "RedHouse")
        {
            transform.parent = null;
            Destroy(gameObject);
            Destroy(_player);
            opScore++;
            Debug.Log(score + ":" + opScore);
            mng.GetComponent<Manager>().Restart();
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
