using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSup : MonoBehaviour
{
    private float countdownTo = 20.0F;


    private void Update()
    {
        countdownTo -= Time.deltaTime;
        if (countdownTo <= 0)
        {
            spawnSup();
        }
    }
    void spawnSup()
    {
        GameObject gameob = PhotonNetwork.Instantiate("Box", new Vector2( Random.Range(-15f,15f), Random.Range(-8f, 4f)), Quaternion.Euler(0f,0f,0f));
        countdownTo = 40f;
    }
}
