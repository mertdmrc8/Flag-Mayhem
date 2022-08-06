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


    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {

        _roomsCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        _roomsCanvases.CurrentRoomsCanvas.Show();
        //Büyük canvalsın leave roomunu göster
        PlayerProperties.in_room_ = true;
        //PlayerProperties.roomid_=PhotonNetwork.CurrentRoom
        
        _content.DestroyChildren();
        print("joined room "); 

        _listings.Clear();
    }



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        print("onroomlist update");
        foreach (RoomInfo info in roomList)
        {

            if (info.RemovedFromList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);

                }

            }
            else
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    Roomlisting listing = Instantiate(_roomlisting, _content);
                    print("oda sahneye eklendi");

                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        print("oda listeye eklendi");
                        _listings.Add(listing);
                    }
                }
                else
                {
                    //Modify listing here. 
                }
            }


        } 

    }

}
