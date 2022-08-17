using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class playerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    float timeUntilFire;
    Character_Controller cc;
    private Camera mainCam;
    private Vector3 mousePos;
    private PhotonView pw;

    private void Awake()
    {
        pw = transform.gameObject.GetComponentInParent<PhotonView>();
    }
    private void Start()
    {

        // if (pw.IsMine)
        // {
        //     mainCam = GameObject.Find("Camera").GetComponent<Camera>();
        // }

        cc = gameObject.GetComponentInParent<Character_Controller>();

        ParticleSystem part = GetComponentInChildren<ParticleSystem>();

    }
    private void Update()
    {


        if (GetComponentInParent<PhotonView>().IsMine == true)
        {

            // mousePos = mainCam.WorldToScreenPoint(Input.mousePosition);
            // Vector3 rotation = mousePos - transform.position;
            // float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.Euler(0, 0, rotZ);

            if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
            {
                 gameObject.GetComponentInParent<PhotonView>().RPC("Shoot", RpcTarget.All, null);
                  Shoot();

                timeUntilFire = Time.time + fireRate;
            }
        }



    }

    void Shoot()
    {
        var part = GetComponentInChildren<ParticleSystem>();
        part.Play();
        float angle = cc.isFacingRight ? 0f : 180f;
        GameObject gameob = PhotonNetwork.Instantiate("Bullet", firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
        gameob.GetComponent<PhotonView>().RPC("destroybullet", RpcTarget.All, this.transform.gameObject.GetComponentInParent<PhotonView>().ViewID);

    }

}
