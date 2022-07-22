using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{

    public GameObject menuCanvas;
    public GameObject roomCanvas;
    void Start()
    {
        
    }
 
    void Update()
    {
        
    }


    public void startbutton(){
        menuCanvas.SetActive(false);
        roomCanvas.SetActive(true) ;
    }
    void CreateRoom() { }
    void JoinRoom() { }

    public void quitbutton(){
      Application.Quit();
    }

  

}
