using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Manager : MonoBehaviourPun,IPunObservable
{
    
   public GameObject _player;
    public GameObject endGame;
    Transform spawnPoint_player1;
    Transform spawnPoint_player2;
    public Text gameScore;
    public Text gameScoreInGame;
    public int Score=0, opScore=0;


    
    void Start()
    {
        spawnPoint_player1 = GameObject.Find("HouseBlue").transform;
        spawnPoint_player2 = GameObject.Find("HouseRed").transform;

       // endGame = GameObject.FindGameObjectWithTag("EndGame");
    }

    private void Update()
    {
        if (Score >= 3 || opScore >= 3)
        {
            //gameScore.text = "BlueTeam: " + mng.GetComponent<Manager>().Score.ToString() + "Red Team" + mng.GetComponent<Manager>().opScore.ToString();
            //endGame.GetComponentInChildren<TextMesh>().text = "BlueTeam: " + mng.GetComponent<Manager>().Score + "Red Team" + mng.GetComponent<Manager>().opScore

            GetComponent<PhotonView>().RPC("EndGame",RpcTarget.All,null);
           EndGame();
        }
        gameScoreInGame.text = "Blue Team : " + Score.ToString()+ "\n" + "Red Team : " + opScore.ToString();
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
        //_player.GetComponent<Character_Controller>().enabled = true;
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
       // _player.GetComponent<Character_Controller>().enabled = false;
        gameScore.text = "BlueTeam: " + Score.ToString() + "Red Team: " + opScore.ToString();
       

        endGame.SetActive(true);

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
     
    }
}
