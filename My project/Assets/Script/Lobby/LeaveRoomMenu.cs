using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class LeaveRoomMenu : MonoBehaviour
{ 

//Room leave 

     private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases){

    _roomsCanvases=canvases; 
    } 

public void Onclick_LeaveRoom(){

    PhotonNetwork.LeaveRoom(true);
    _roomsCanvases.CurrentRoomsCanvas.Hide();
}

}
