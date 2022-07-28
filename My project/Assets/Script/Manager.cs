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
    public int Score=0, opScore=0;


    
    void Start()
    {
        spawnPoint_player1 = GameObject.Find("HouseBlue").transform;
        spawnPoint_player2 = GameObject.Find("HouseRed").transform;

        
    }

    private void Update()
    {
       
    }

    [PunRPC]
    public void GameStart()
    {
        var clones = GameObject.FindGameObjectsWithTag("Player");


       

        GetComponent<PhotonView>().RPC("SpawnPlayer", RpcTarget.All, null);
        //GetComponent<PhotonView>().RPC("SpawnFlag", RpcTarget.All, null);
        //SpawnPlayer();
        SpawnFlag();
    }
    [PunRPC]
    public void Restart()
    {
        var clones = GameObject.FindGameObjectsWithTag("Player");
        foreach (var clone in clones)
        {
            Destroy(clone.gameObject);
        }
        Destroy(_player.gameObject);

        GetComponent<PhotonView>().RPC("SpawnPlayer", RpcTarget.All, null);
        GetComponent<PhotonView>().RPC("SpawnFlag", RpcTarget.All, null);

        //SpawnPlayer();
        //SpawnFlag();

    }
    [PunRPC]
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
    [PunRPC]
    public void SpawnFlag() {

        GameObject Flag = PhotonNetwork.Instantiate("Flag",new Vector3(0,3,0), Quaternion.identity, 0, null) as GameObject;
    }
    [PunRPC]
    public void Win() {


    }
    [PunRPC]
    public void Lose()
    {

    }
    
    

    
}
