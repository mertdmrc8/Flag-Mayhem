using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{     

  

    public void startbutton(){
        SceneManager.LoadScene(1);
    }

    public void quitbutton(){
      Application.Quit();
    }
    public void Onclick_LeaveGame(){

        PhotonNetwork.LeaveRoom(true);
       

    }

}
