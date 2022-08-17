using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System;

public class playerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bullet;
    public GameObject multipleBullet;
    public GameObject  rapidBullet;

    public GameObject bulletType;

    public GameObject dynamite;
    bool isThrow=false;
    float timeUntilFire;
    Character_Controller cc;
    Animation anim;


   

    
    


    private void Start()
    {
        cc = gameObject.GetComponent<Character_Controller>();

        ParticleSystem part = GetComponentInChildren<ParticleSystem>();

    }
    private void Update()
    {
        if (GetComponent<PhotonView>().IsMine == true)
        {
            if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
            {
                //gameObject.GetComponent<PhotonView>().RPC("Shoot", RpcTarget.All, null);
                Shoot();

                timeUntilFire = Time.time + fireRate;
            }
            if (Input.GetMouseButtonDown(1))
            {
                ThrowGrenade();
            }
        }



    }

   

    void Shoot()
    {
        var part = GetComponentInChildren<ParticleSystem>();
        part.Play();
        float angle = cc.isFacingRight ? 0f : 180f;
        //GameObject gameob = PhotonNetwork.Instantiate(bulletType, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle))) as GameObject;
        //gameob.GetComponent<PhotonView>().RPC("destroybullet", RpcTarget.All, this.transform.gameObject.GetComponent<PhotonView>().ViewID);


        switch (cc.wMod)
        {
            case Character_Controller.weaponMod.mode1:
                bulletType = multipleBullet;
                GameObject gameob = PhotonNetwork.Instantiate("MultipleBullet", firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle))) as GameObject;
                gameob.GetComponent<PhotonView>().RPC("destroybullet", RpcTarget.All, this.transform.gameObject.GetComponent<PhotonView>().ViewID);

                break;
            case Character_Controller.weaponMod.mode2:
               bulletType = rapidBullet;
                GameObject gameob1 = PhotonNetwork.Instantiate("RapidBullet", firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle))) as GameObject;
                gameob1.GetComponent<PhotonView>().RPC("destroybullet", RpcTarget.All, this.transform.gameObject.GetComponent<PhotonView>().ViewID);
                break;
            
            default:
                bulletType = bullet;
                GameObject gameob2 = PhotonNetwork.Instantiate("Bullet", firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle))) as GameObject;
                gameob2.GetComponent<PhotonView>().RPC("destroybullet", RpcTarget.All, this.transform.gameObject.GetComponent<PhotonView>().ViewID);
                break;
        }


       
        



    }


    private void ThrowGrenade(){
       
    }


    void changeWeaponMod()
    {
       
    }




}
