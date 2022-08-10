using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerDatabase : MonoBehaviourPunCallbacks
{


    readonly string saved_posturl = "http://localhost:8080/UserArchive/GameScores";



    [PunRPC]
    public void UpdateAndAddData(int score, int death, int kill)
    {
        PlayerProperties.score_ += score;
        PlayerProperties.death_ += death;
        PlayerProperties.kill_ += kill;

    }
    [PunRPC]
    private void UpdateMatchData(int win, int lose)
    {
        PlayerProperties.win_ += win;
        PlayerProperties.lose_ += lose; 
 
 
    }

    private void SavedPlayerGameInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", PlayerProperties.id_);
        form.AddField("score", PlayerProperties.score_);
        form.AddField("kill", PlayerProperties.kill_);
        form.AddField("death", PlayerProperties.death_);
        form.AddField("lose", PlayerProperties.lose_);
        form.AddField("win", PlayerProperties.win_);




        UnityWebRequest www = UnityWebRequest.Post(saved_posturl, form);
        www.SetRequestHeader("token", PlayerProperties.token_);

        www.SendWebRequest();


    }
    public override void OnLeftRoom()
    {
        print("onleftroom");
        SavedPlayerGameInfo();
        SceneManager.LoadScene(1);
    }

    // public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    // {
    //     if( stream.IsWriting){
    //         stream.SendNext(sayi);

    //     } 

    // }
}
