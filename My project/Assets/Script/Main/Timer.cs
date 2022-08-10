using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text countdownText;
    float countdownTo = 60.0F;

    readonly string saved_gameScore = "http://localhost:8080/UserArchive/GameScores";

    private void Start()
    {
        countdownText = GameObject.Find("CountdownText").GetComponent<Text>();
    }

    private void Update()
    {
        countdownTo -= Time.deltaTime;

        if (countdownTo > 0)
        {
            countdownText.text = countdownTo.ToString().Substring(0, 2);
        }
        else
        {
            // this.gameObject.SetActive(false);

            PhotonNetwork.LeaveRoom(true);
            if (PlayerProperties.OnLogin_)
            {
                StartCoroutine(UserSaved());
            }
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
