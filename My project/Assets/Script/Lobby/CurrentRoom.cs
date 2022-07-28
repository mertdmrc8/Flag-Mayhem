using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    //mevcut oda

    [SerializeField]
    private PlayerListingsMenu _playerListingsMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {

        //Sahne Canvas        
        _roomsCanvases = canvases;
        _playerListingsMenu.FirstInitialize(canvases);
        _leaveRoomMenu.FirstInitialize(canvases);

        
    }

    public void Show()
    {
        gameObject.SetActive(true);

    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
