using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Flag : MonoBehaviourPun, IPunObservable
{

    GameObject mng;
    GameObject _player;
    GameObject endGame;
    TextMesh gameScore;

    private void Start()
    {
        mng = GameObject.Find("Manager");
        _player = GameObject.FindGameObjectWithTag("Player");
        //endGame = GameObject.FindGameObjectWithTag("Endgame");
        //gameScore = endGame.GetComponentInChildren<text>();


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject Player = null;

        if (collision.tag == "Player")
        {
            Player = collision.gameObject;

            this.transform.parent = Player.transform;

            transform.position = new Vector3(0,2,0);
        }
        else if (collision.tag == "BlueHouse")
        {
            transform.parent = null;

            mng.GetComponent<Manager>().Score++;
            Debug.Log(mng.GetComponent<Manager>().Score + ":" + mng.GetComponent<Manager>().opScore);
            transform.position = new Vector3(0, 3f, 0);
            _player.GetComponent<Health>().Respawn();

            //Destroy(gameObject);
            //mng.GetComponent<PhotonView>().RPC("Restart", RpcTarget.All, null);
            //mng.GetComponent <Manager>().Restart();


        }
        else if (collision.tag == "RedHouse")
        {
            transform.parent = null;
            mng.GetComponent<Manager>().opScore++;
            Debug.Log(mng.GetComponent<Manager>().Score + ":" + mng.GetComponent<Manager>().opScore);
            transform.position = new Vector3(0, 3f, 0);
            StartCoroutine(_player.GetComponent<Health>().Respawn());


            //Destroy(gameObject);
            // mng.GetComponent<PhotonView>().RPC("Restart",RpcTarget.All,null);
            //mng.GetComponent<Manager>().Restart();
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
    private void Update()
    {
        if (mng.GetComponent<Manager>().Score >= 3 || mng.GetComponent<Manager>().opScore >= 3)
        {
            //gameScore.text = "BlueTeam: " + mng.GetComponent<Manager>().Score.ToString() + "Red Team" + mng.GetComponent<Manager>().opScore.ToString();
            //endGame.GetComponentInChildren<TextMesh>().text = "BlueTeam: " + mng.GetComponent<Manager>().Score + "Red Team" + mng.GetComponent<Manager>().opScore

            mng.GetComponent<Manager>().EndGame();
        }
    }
}
