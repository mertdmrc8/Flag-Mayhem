using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class playerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bullet;
    float timeUntilFire;
    Character_Controller cc;


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
        }



    }
    [PunRPC]
    void Shoot()
    {
        var part = GetComponentInChildren<ParticleSystem>();
        part.Play();
        float angle = cc.isFacingRight ? 0f : 180f;
        GameObject gameob = PhotonNetwork.Instantiate("Bullet", firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        Bullet bullet_ = gameob.GetComponent<Bullet>();
        StartCoroutine(bullet_.DestroyBullet());
    }

     
  

}
