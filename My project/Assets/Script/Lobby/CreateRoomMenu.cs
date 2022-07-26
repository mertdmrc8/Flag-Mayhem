using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;



 
    private RoomsCanvases _roomsCanvases; 
 
    public void FirstInitialize(RoomsCanvases canvases){

    _roomsCanvases=canvases;
    } 


    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        print("joined lobby  ");

    }
    
    public void onClick_CreateRoom(){

        if(!PhotonNetwork.IsConnected)
            return;
         RoomOptions options= new RoomOptions(); 
         options.MaxPlayers=2;
          PhotonNetwork.JoinOrCreateRoom(_roomName.text,options,TypedLobby.Default );


    }
     


    public override void OnCreatedRoom()
    { 
        print("CreateRoon Succesfuly ");
        _roomsCanvases.CurrentRoomsCanvas.Show();

    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("CreateRoon failed ");
    }
}
