using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class Grenade : MonoBehaviour
{
    public float grenadeSpeed = 10f;
    public Vector3 launchOffset;
    public bool thrown;

    public Rigidbody2D rb;
    PhotonView pw_b;
    public GameObject ordinary;
    public int incoming_id;

    private void Awake()
    {


    }
    private void Start()
    {
        

    }
    private void FixedUpdate()
    {

       


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

       


    }


  



    

}
