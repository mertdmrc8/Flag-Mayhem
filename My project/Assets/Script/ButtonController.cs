using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviourPunCallbacks
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
 
    public void return_main(){
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene(0);
        
    }

        




}

