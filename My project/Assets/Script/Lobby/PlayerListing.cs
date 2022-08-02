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
    
    public Player Player {get; private set ;}   
 
   public void SetPlayerInfo(Player player){
    Player=player;
    nick_name.text = player.NickName;
    
    

     

    }
}
