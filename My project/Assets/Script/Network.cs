using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Network : MonoBehaviourPunCallbacks
{
    //Transform spawnPoint_player1;
    //Transform spawnPoint_player2;
    //Transform spawnPoint_Flag;
    public GameObject manager;
    GameObject mng;


    PhotonView pw;
    void Start()
    {
        PhotonNetwork.SendRate = 40;
        PhotonNetwork.SerializationRate = 40;
        PhotonNetwork.AutomaticallySyncScene = true;


        //spawnPoint_player1 = GameObject.Find("HouseBlue").transform;
        //spawnPoint_player2 = GameObject.Find("HouseRed").transform;

        manager.GetComponent<Manager>();



        PhotonNetwork.ConnectUsingSettings();


    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("lobiye girlidi");



        PhotonNetwork.JoinOrCreateRoom("oda", new RoomOptions { MaxPlayers = 4, IsOpen = true, IsVisible = true }, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("odaya girildi");

        
            manager.GetComponent<Manager>().GameStart();

       
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    //GameObject Player = PhotonNetwork.Instantiate("Ordinary", Vector3.zero, Quaternion.identity, 0, null) as GameObject;
        //    GameObject Player = PhotonNetwork.Instantiate("Ordinary",spawnPoint_player1.transform.position,spawnPoint_player1.transform.rotation,0,null) as GameObject;
        //}
        //else
        //{
        //    GameObject Player = PhotonNetwork.Instantiate("Ordinary", spawnPoint_player2.transform.position, spawnPoint_player2.transform.rotation, 0, null) as GameObject;

        //    GameObject Flag = PhotonNetwork.Instantiate("Flag", new Vector3(0,2,0), Quaternion.identity, 0, null) as GameObject;
        //}





    }


}
