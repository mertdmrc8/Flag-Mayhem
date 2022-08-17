using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
 
    private Transform aimTransform; 
    // Start is called before the first frame update
    void Start()
    {
        
        aimTransform=transform.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
