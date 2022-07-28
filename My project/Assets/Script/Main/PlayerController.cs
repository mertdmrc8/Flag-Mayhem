using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPunCallbacks
{
    
     void Start()
    {
        print("onjoined room");
        GameObject Player = PhotonNetwork.Instantiate("Ordinary", Vector3.zero, Quaternion.identity, 0, null) as GameObject;
        GameObject Bullet = PhotonNetwork.Instantiate("Bullet", Vector3.zero, Quaternion.identity, 0, null);
    }



}
