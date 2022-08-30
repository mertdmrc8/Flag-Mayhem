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
    private int room_sira = -1;



    void Awake()
    {
        // print("asdadaf");
        // PhotonNetwork.AutomaticallySyncScene = true;
        // GetCurrentRoomPlayers();
    }
     



    public void FirstInitialize(RoomsCanvases canvases)
    {
        print("fi");
        _roomsCanvases = canvases;
    }


    // public override void OnLeftRoom()
    // {   print("destroy child");
    //     _content.DestroyChildren();
    // }
    public void GetCurrentRoomPlayers()
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
            room_sira++;


        }
        setroomid();

    }

    private void AddPlayerListing(Player player)
    {

        PlayerListing listing = Instantiate(_playerlisting, _content);
 
        if (listing != null)
        { 
            listing.SetPlayerInfo(player);
         
            _listings.Add(listing);
        }

    }

    public void OnClickStart()
    {
        if (PlayerProperties.sira_ == 0)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(2); 
        }


    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    { 
        AddPlayerListing(newPlayer);
        setroomid();

    }
    //baska biri odadan çıkınca 
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {

        print(_listings.Count);
        foreach (var item in _listings)
        {
            print(item);
        }

        int index = _listings.FindIndex(x => x.Player == otherPlayer);

        //çıkann indexi listede olmuor sebeb
        if (index != -1)
        {   //sıkıntı burda 
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }


    private void setroomid()
    {
        int i = 0;

        PlayerProperties.sira_ = room_sira;
        
       print("sira "+ PlayerProperties.sira_) ;
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {


            if (playerInfo.Value.UserId == PhotonNetwork.LocalPlayer.UserId)
            {
                PlayerProperties.roomid_ = playerInfo.Value.ActorNumber - 1;
            }

            i++;
        }

        if (PlayerProperties.sira_ != 0)
        {
            GameObject StartGameButton = transform.Find("StartGame").gameObject;
            StartGameButton.SetActive(false);
        }

    }
}
