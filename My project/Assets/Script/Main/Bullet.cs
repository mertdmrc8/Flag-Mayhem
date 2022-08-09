using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public Rigidbody2D rb;
    PhotonView pw_b;

    public GameObject ordinary;
 
    private void Awake(){ 

        
    }
    private void Start()
    {
        pw_b = GetComponent<PhotonView>();
    }
    private void FixedUpdate()
    {

        rb.velocity = transform.right * bulletSpeed;


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);



    }


    [PunRPC]
    public void destroybullet(int ordinaryid){
        //PhotonNetwork.GetPhotonView(ordinaryid);
        GameObject ordinary_=PhotonNetwork.GetPhotonView(ordinaryid).gameObject;
        this.ordinary = ordinary_.gameObject ;
        StartCoroutine(wait(ordinary_));
    }
    

    
    public IEnumerator wait(GameObject ordinary_)
    {

        //burda atıyor karşıda nasıl atama yapıcak 
         yield return new WaitForSeconds(1f);
        try
        {
            Destroy(gameObject); 
        }
        catch
        { 

        }
    }

}
