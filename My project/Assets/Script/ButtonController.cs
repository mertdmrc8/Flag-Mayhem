using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{


    readonly string saved_gameScore = "http://localhost:8080/UserArchive/GameScores";

    public void startbutton()
    {
        SceneManager.LoadScene(1);
    }

    public void quitbutton()
    {
        Application.Quit();
    }
    public void Onclick_LeaveGame()
    {

        PhotonNetwork.LeaveRoom(true); 
        if (PlayerProperties.OnLogin_)
        {
            StartCoroutine(UserSaved());
        }

    }
    IEnumerator UserSaved()
    {
        WWWForm form = new WWWForm();
        form.AddField("id", PlayerProperties.id_);
        form.AddField("score", PlayerProperties.score_);
        form.AddField("kill", PlayerProperties.kill_);
        form.AddField("death", PlayerProperties.death_);

        UnityWebRequest www = UnityWebRequest.Post(saved_gameScore, form);
        www.SetRequestHeader("Authorization", "Bearer " + PlayerProperties.token_);
        var operation = www.SendWebRequest();
        yield return operation;
    }
}
