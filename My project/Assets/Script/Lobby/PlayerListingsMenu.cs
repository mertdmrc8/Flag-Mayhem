using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;


    [SerializeField]
    private PlayerListing _playerlisting;

    private List<PlayerListing> _listings = new List<PlayerListing>();
    private RoomsCanvases _roomsCanvases;

    [SerializeField]
    private Button button;


    private void Awake()
    {

        GetCurrentRoomPlayers();
    }

    public void FirstInitialize(RoomsCanvases canvases)
    {

        _roomsCanvases = canvases;
    }


    public override void OnLeftRoom()
    {
        _content.DestroyChildren();
    }
    private void GetCurrentRoomPlayers()
    {


        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.PlayerList == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
         }
        setroomid();

    }

    private void AddPlayerListing(Player player)
    {

        PlayerListing listing = Instantiate(_playerlisting, _content);

        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            print(listing.userid);
            print(listing.name);
            _listings.Add(listing);
        }
    }

    public void OnClickStart()
    {


        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
        }
        PhotonNetwork.LoadLevel(3);

    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("on player entered room__");
        AddPlayerListing(newPlayer);
        setroomid();

    }
    //baska biri odadan çıkınca 
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {


        print("0nplayerleftroom index");
        print(_listings.Count);
        foreach (var item in _listings)
        {
            print(item);
        }

        int index = _listings.FindIndex(x => x.Player == otherPlayer);

        //çıkann indexi listede olmuor sebeb
        if (index != -1)
        {   //sıkıntı burda
            print("0nplayerleftroom");
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }


    private void setroomid()
    {
        int i = 0;
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {     

            print( "i degeri"+playerInfo.Key);
            if (playerInfo.Value.UserId == PhotonNetwork.LocalPlayer.UserId)
            { 
                    PlayerProperties.roomid_=playerInfo.Value.ActorNumber-1;
            }
             
            i++;
        }

    }
}
