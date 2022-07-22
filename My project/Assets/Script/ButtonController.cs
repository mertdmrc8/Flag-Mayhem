using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{      void Start()
    {
        
    }
 
    void Update()
    {
        
    }


    public void startbutton(){
        SceneManager.LoadScene(1);
    }

    public void quitbutton(){
      Application.Quit();
    }

  

}
