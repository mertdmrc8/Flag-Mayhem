using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour


{
    GameObject mng;

    void Start()
    {
        mng = GameObject.Find("Manager");
    }

    void Update()
    {

    }

    public void playAgainButton()
    {
        mng.GetComponent<Manager>().Restart();
    }
    public void startbutton()
    {
        SceneManager.LoadScene(1);
    }

    public void quitbutton()
    {
        Application.Quit();
    }



}
