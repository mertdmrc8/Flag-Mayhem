using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        print("connecting to server");
        
        PhotonNetwork.NickName=MasterManager.GameSettings.NicName;
        PhotonNetwork.GameVersion=MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
         
    }


    public override void OnConnectedToMaster()
    {
        print("Connected to server");
        print(PhotonNetwork.LocalPlayer.NickName);


        if(!PhotonNetwork.InLobby){
            PhotonNetwork.JoinLobby();
        }
        print("joined lobby  ");

    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from server for reason" + cause.ToString());

    }
}
