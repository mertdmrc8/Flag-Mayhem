using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("lobiye girlidi");

        PhotonNetwork.JoinOrCreateRoom("oda", new RoomOptions {MaxPlayers=2,IsOpen=true,IsVisible=true },TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("odaya girlidr");
        GameObject Player = PhotonNetwork.Instantiate("Ordinary", Vector3.zero, Quaternion.identity, 0, null);
    }
    void Update()
    {
        
    }
    
}
