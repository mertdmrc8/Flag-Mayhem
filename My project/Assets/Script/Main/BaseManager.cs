using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{ 
    [SerializeField]
    private Flagbase flagbase;
    private void OnTriggerEnter2D(Collider2D collision){


        Flag flag = collision.gameObject.transform.GetComponent<Flag>();
        TeamManager Team = gameObject.transform.parent.GetComponent<TeamManager>();

        if(flag!=null&& flag.player==Team.Player){ 
            Destroy(flag.gameObject);    
            flagbase.CreateFlag();

        }
    }
}
