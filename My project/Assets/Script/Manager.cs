using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Manager : MonoBehaviourPun
{
    
   public GameObject _player;
    public GameObject endGame;
    Transform spawnPoint_player1;
    Transform spawnPoint_player2;
    public Text gameScore;
    public int Score=0, opScore=0;


    
    void Start()
    {
        spawnPoint_player1 = GameObject.Find("HouseBlue").transform;
        spawnPoint_player2 = GameObject.Find("HouseRed").transform;

       // endGame = GameObject.FindGameObjectWithTag("EndGame");
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

       
        if (PhotonNetwork.IsMasterClient)
        {
            _player.transform.position = new Vector3(9, 0.5f, 0);
        }
        else
        {
           _player.transform.position = new Vector3(-9, 0.5f, 0);
        }
        endGame.SetActive(false);
        Score = 0;
        opScore = 0;
        //GetComponent<PhotonView>().RPC("SpawnPlayer", RpcTarget.All, null);
        //GetComponent<PhotonView>().RPC("SpawnFlag", RpcTarget.All, null);

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
        endGame.SetActive(true);

    }
    [PunRPC]
    public void EndGame()
    {
        gameScore.text = "BlueTeam: " + Score.ToString() + "Red Team: " + opScore.ToString();
        endGame.SetActive(true);
    }
    
    

    
}
