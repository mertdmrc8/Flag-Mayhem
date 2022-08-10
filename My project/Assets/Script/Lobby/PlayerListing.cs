using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviour
{
    //Player
    [SerializeField]
    private Text  nick_name;
    
    public string userid;
    public Player Player {get; private set ;}   
 
   public void SetPlayerInfo(Player player){
    Player=player;
    print("nickname:::"+ player.NickName);
    nick_name.text = player.NickName;
    userid =player.UserId;

     

    }
}
