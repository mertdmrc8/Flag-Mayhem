using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;


    [SerializeField]
    private Roomlisting _roomlisting;

    private List<Roomlisting> _listings = new List<Roomlisting>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        print("onroomlist update");
        foreach (RoomInfo info in roomList)
        {
             print("for ");
            if (info.RemovedFromList)
            {
                print("if "); 
                int index=_listings.FindIndex(x=>x.RoomInfo.Name ==info.Name );
                if(index!=-1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);

                }

            }
            else
            {
                print("else ");
                Roomlisting listing = Instantiate(_roomlisting, _content);
               
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    _listings.Add(listing);
                }
            }


        }

    }


}
