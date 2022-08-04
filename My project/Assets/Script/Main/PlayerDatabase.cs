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

    void Start()
    {
        print("onjoined room");
        GameObject Player = PhotonNetwork.Instantiate("Ordinary", Vector3.zero, Quaternion.identity, 0, null) as GameObject;
        GameObject Bullet = PhotonNetwork.Instantiate("Bullet", Vector3.zero, Quaternion.identity, 0, null);


    }

    private void SavedPlayerGameInfo()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", PlayerProperties.id_);
        form.AddField("score", PlayerProperties.score_);
        form.AddField("kill", PlayerProperties.kill_);
        form.AddField("death", PlayerProperties.death_);


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



}
