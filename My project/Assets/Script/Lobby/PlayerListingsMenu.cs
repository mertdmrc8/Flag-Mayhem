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


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
          print("else ");
                PlayerListing listing = Instantiate(_playerlisting, _content);
               
                if (listing != null)
                {
                    listing.SetPlayerInfo(newPlayer);
                    _listings.Add(listing);
                }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    { 
                print("if "); 
                int index=_listings.FindIndex(x=>x.Player ==otherPlayer );
                if(index!=-1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                } 
    }  
}
