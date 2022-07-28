using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
    }


    private void OnTriggerEnter2D(Collider2D collision){


        Flag flag = collision.gameObject.transform.GetComponent<Flag>();
        if(flag!=null){

            Destroy(flag.gameObject);            
        }
    }
}
