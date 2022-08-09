using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private Text countdownText;
    float countdownTo = 60.0F;


    private void Start()
    {
        countdownText = GameObject.Find("CountdownText").GetComponent<Text>();
    }

    private void Update()
    {
        countdownTo -= Time.deltaTime;

        if (countdownTo > 0)
        {
            countdownText.text = countdownTo.ToString().Substring(0,2);
        }
        else{
            this.gameObject.SetActive(false); 
            //nesne sahnede bulunabiliyor
        }

        //timerText.text = DateTime.Now.ToString("hh:MM:ss");
    }
}
