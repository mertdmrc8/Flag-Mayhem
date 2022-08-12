using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
public class Players_Controller : MonoBehaviour
{
    public TeamManager TeamRed;
    public TeamManager TeamBlue; 
    public List<PhotonView> photonViews = new List<PhotonView>();

      public TeamManager getCurrentTeam()
    {
        if (TeamBlue.team_players.Count == TeamRed.team_players.Count)
        {
            return TeamBlue;
        }
        else if (TeamBlue.team_players.Count > TeamRed.team_players.Count)
        {
            return TeamRed;
        }
        else
        {
            return TeamBlue;
        }
    }



    void Start()
    {
        print("onjoined main");

        object[] PlayerData = { PlayerProperties.roomid_ };
        GameObject Gameob = PhotonNetwork.Instantiate("Ordinary", Vector3.zero, Quaternion.identity, 0, PlayerData);
        Gameob.GetComponent<PhotonView>().RPC("SetTeam", RpcTarget.All, null);

    }


    // Update is called once per frame
    void Update()
    {



    }


}
