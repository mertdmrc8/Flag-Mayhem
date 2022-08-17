using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class Players_Controller : MonoBehaviourPun
{
    public TeamManager TeamRed;
    public TeamManager TeamBlue;
    public List<PhotonView> photonViews = new List<PhotonView>();
    private Boolean youTurn = false;
    private int nextPlayerid;
    private int next_playerCount = 0;
    private int roomPLayer_count;
    private int return_countinfo = 0;
    private GameObject self_Ordinary;
    private int self_viewİd;
    private bool SetTeam = true;
    private CameraManager Camera;
    public List<PhotonView> photonviewlist;
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
    void Awake()
    {
        Camera= GameObject.Find("Camera").gameObject.GetComponent<CameraManager>();
        
    }


    void Start()
    {

        object[] PlayerData = { PlayerProperties.roomid_ };

        self_Ordinary = PhotonNetwork.Instantiate("Player_Soldier", Vector3.zero, Quaternion.identity, 0, PlayerData);
        Camera.Ordinary=self_Ordinary;
        self_viewİd = self_Ordinary.GetComponent<PhotonView>().ViewID;
        photonviewlist.Add(self_Ordinary.GetComponent<PhotonView>());
        get_next_player();

    }


    // Update is called once per frame
    void Update()
    {
        if (SetTeam)
        {
            if (nextPlayerid == self_viewİd)
            {
                print("youTurn");
                youTurn = true;//sıradaki oyncu beniyim
            }
            else if (null != PhotonNetwork.GetPhotonView(nextPlayerid))// o oyuncu yu bul sahne de viewi
            {
                next_playerCount++;//değilsem bekle 
                print("next player");
                get_next_player();
            }




            if (youTurn)
            {
                youTurn = false;
                print("onjoined main");
                self_Ordinary.GetComponent<PhotonView>().RPC("SetTeam", RpcTarget.All, null);
                next_playerCount++;
                get_next_player();
            }


        }

    }

    private void get_next_player()
    {

        if (next_playerCount<PhotonNetwork.CurrentRoom.PlayerCount-1)
        {
            int j=0;
            foreach (PhotonView view in photonviewlist)
            {

                if (next_playerCount == j)
                {
                    nextPlayerid = view.ViewID;
                    break;
                }
                j++;
            }
        }else{
            SetTeam=false;
        }
    }

}
