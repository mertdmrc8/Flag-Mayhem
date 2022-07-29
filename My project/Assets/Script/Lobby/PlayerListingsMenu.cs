using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{  
[SerializeField]
    private Transform _content;


    [SerializeField]
    private PlayerListing _playerlisting;

    private List<PlayerListing> _listings = new List<PlayerListing>();
    private RoomsCanvases _roomsCanvases;


    private void Awake(){

        GetCurrentRoomPlayers();
    }

     public void FirstInitialize(RoomsCanvases canvases){

            _roomsCanvases=canvases; 
    } 


    public override void OnLeftRoom(){
        _content.DestroyChildren();
    }  
    private void GetCurrentRoomPlayers(){


        if(!PhotonNetwork.IsConnected){
            return;
        }
        if(PhotonNetwork.CurrentRoom==null|| PhotonNetwork.PlayerList==null){
            return;
        }

        foreach (KeyValuePair <int , Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
                AddPlayerListing(playerInfo.Value);
        }
         
    }

    private void AddPlayerListing(Player player){

         PlayerListing listing = Instantiate(_playerlisting, _content);
               
                if (listing != null)
                {
                    listing.SetPlayerInfo(player);
                    print(listing.name);
                    _listings.Add(listing);
                } 

    }

    public  void OnClickStart(){
        if(PhotonNetwork.IsMasterClient){
            PhotonNetwork.CurrentRoom.IsOpen=false;
            PhotonNetwork.CurrentRoom.IsVisible=false;
            }
            PhotonNetwork.LoadLevel(2);
        
    }
    


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
                AddPlayerListing(newPlayer); 
        
               
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

                int index=_listings.FindIndex(x=>x.Player ==otherPlayer );
            
                //çıkann indexi listede olmuor sebeb
                if(index!=-1)
                {   //sıkıntı burda
                    print("0nplayerleftroom");
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                } 
    }  
}
