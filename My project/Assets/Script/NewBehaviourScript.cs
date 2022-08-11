using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NewBehaviourScript : MonoBehaviour
{
    PhotonView pw;

    private void Start()
    {
        ParticleSystem part = GetComponentInChildren<ParticleSystem>();
        

    }
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.tag == ("Flag"))
        {
            var part = GetComponentInChildren<ParticleSystem>();
            part.Play();
        }
    }
}
