using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Manager : MonoBehaviourPun
{
    
   public GameObject _player;
    Transform spawnPoint_player1;
    Transform spawnPoint_player2;
    Transform spawnPoint_Flag;

    
    void Start()
    {
        spawnPoint_player1 = GameObject.Find("HouseBlue").transform;
        spawnPoint_player2 = GameObject.Find("HouseRed").transform;
    }




    public void GameStart()
    {
        SpawnPlayer();
        SpawnFlag();
    }
    public void Restart()
    {
        SpawnPlayer();
        SpawnFlag();

    }
     public void SpawnPlayer()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GameObject Player = PhotonNetwork.Instantiate("Ordinary", spawnPoint_player1.transform.position, spawnPoint_player1.transform.rotation, 0, null) as GameObject;
        }
        else
        {
            GameObject Player = PhotonNetwork.Instantiate("Ordinary", spawnPoint_player2.transform.position, spawnPoint_player2.transform.rotation, 0, null) as GameObject;
        }
       
    }
     public void SpawnFlag() {

        GameObject Flag = PhotonNetwork.Instantiate("Flag",new Vector3(0,3,0), Quaternion.identity, 0, null) as GameObject;
    }
     public void Win() {


    }
     public void Lose()
    {

    }
    
    

    
}
