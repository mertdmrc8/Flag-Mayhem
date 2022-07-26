using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviourPun
{
    
   public GameObject _player;

    private void Start()
    {

    }
   
    public void SpawnPlayer()
    {
        GameObject Player = PhotonNetwork.Instantiate("Ordinary", Vector3.zero, Quaternion.identity, 0, null) as GameObject;
    }
     public void SpawnFlag() {

        GameObject Flag = PhotonNetwork.Instantiate("Flag", Vector3.zero, Quaternion.identity, 0, null) as GameObject;
    }
     public void Win() {


    }
     public void Lose()
    {

    }
    


    
}
