using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
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
            this.gameObject.SetActive(false);
            StartCoroutine(UserSaved());
            //nesne sahnede bulunabiliyor
        }

    }
    IEnumerator UserSaved()
    {

        yield return new WaitForSeconds(1);
    //     WWWForm form = new WWWForm();
    //     form.AddField("email", email);
    //     form.AddField("password", password);

    //     UnityWebRequest www = UnityWebRequest.Post(saved_gameScore, form);

    //     var operation = www.SendWebRequest();
    //     yield return operation;

    //     if (www.result == UnityWebRequest.Result.Success)
    //     {
    //         print("login den donen");
    //         Debug.Log($"response: {www.downloadHandler.text}");

    //         Data stuff = JsonConvert.DeserializeObject<Data>($"{www.downloadHandler.text}");
    //         PlayerProperties.token_ = stuff.token;
    //         PlayerProperties.id_ = stuff.id;
    //         print("token ve id kayıt ");
    //         print("token:" + PlayerProperties.token_);
    //         print("id:" + PlayerProperties.id_);
    //     }
    //     else
    //         Debug.Log("response failed");


    //     if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //     {

    //         print(www.error);
    //     }
     }
    
}
