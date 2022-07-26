using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviourPunCallbacks, IPunObservable
{
    public int health = 2;
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (int)stream.ReceiveNext();
        }

    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    IEnumerator Respawn()
    {
        health = 2;
        GetComponent<Character_Controller>().enabled = false;
        transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2);
        GetComponent<Character_Controller>().enabled = true;
       


    }
    private void Update()
    {
        if (health<=0)
        {
            StartCoroutine(Respawn());
        }
    }
}
