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
        
    }
    private void Update()
    {
        if (GetComponent<PhotonView>().IsMine == true)
        {
            if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
            {
                Shoot();
                timeUntilFire = Time.time + fireRate;
            }
        }



    }

    void Shoot()
    {
        float angle = cc.isFacingRight ? 0f : 180f;
        PhotonNetwork.Instantiate("Bullet", firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));

    }

}
