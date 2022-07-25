using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviourPunCallbacks, IPunObservable 
{
    
    public int localHealth = 5;
    public int enemyHealth=5;

    PhotonView pw;

    GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        
    }


    void dead()
    {

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(localHealth);
        }
        else
        {
            localHealth = (int)stream.ReceiveNext();
        }
    }
}
