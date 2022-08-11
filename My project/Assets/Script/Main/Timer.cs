using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    //Bu obje static olabilir.

    private Text countdownText;
    float countdownTo = 6.0F;
    GameObject thisplayer;

    [SerializeField]
    private TeamManager TeamRed;

    [SerializeField]
    private TeamManager TeamBlue;


    readonly string saved_gameScore = "http://localhost:8080/UserArchive/GameScores";

    private void Start()
    {
        countdownText = GameObject.Find("CountdownText").GetComponent<Text>();
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.T)){

        }

        countdownTo -= Time.deltaTime;

        if (countdownTo > 0)
        {
            countdownText.text = countdownTo.ToString().Substring(0, 2);
        }
        else
        {
            if (PlayerProperties.OnLogin_)
            {
                WonOrLost();
                saved_score();
                StartCoroutine(UserSaved());
            }
        }
    }
    public void Onclick_LeaveGame()
    {

        PhotonNetwork.LeaveRoom(true);
        if (PlayerProperties.OnLogin_)
        {
            WonOrLost();
            saved_score();
            StartCoroutine(UserSaved());
        }

    }
    private void WonOrLost()
    {
        if (TeamBlue.TeamScore > TeamRed.TeamScore)
        {
            TeamBlue.boolWon = true;
        }
        else
        {
            TeamRed.boolWon = true;
        };
    }
    private void saved_score()
    {
        if (thisplayer.GetComponent<PhotonView>().IsMine)
        {
            if (thisplayer.GetComponent<Character_Controller>().Team.boolWon)
            {
 
                PlayerProperties.win_ = 1;
            }
            else
            {
                PlayerProperties.lose_ = 1;
            }
        }


    }
    private void deneme(){
        print(thisplayer.GetComponent<Character_Controller>().Team.TeamName+" t ye basıldı");
    }


    IEnumerator UserSaved()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", PlayerProperties.id_);
        form.AddField("score", PlayerProperties.score_);
        form.AddField("kill", PlayerProperties.kill_);
        form.AddField("death", PlayerProperties.death_);
        form.AddField("lose", PlayerProperties.lose_);
        form.AddField("win", PlayerProperties.win_);

        UnityWebRequest www = UnityWebRequest.Post(saved_gameScore, form);
        www.SetRequestHeader("Authorization", "Bearer " + PlayerProperties.token_);
        var operation = www.SendWebRequest();
        yield return operation;
    }

}
