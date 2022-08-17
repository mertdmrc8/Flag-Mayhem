using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class denemeShoting : MonoBehaviour
{
    // Start is called before the first frame update

     private Camera mainCam;
    private Vector3 mousePos;
    void Start()
    {
        
        mainCam= GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos=mainCam.ScreenToWorldPoint(Input.mousePosition); 
        Vector3 rotation =mousePos-transform.position; 
        float rotZ = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg; 
        transform.rotation=Quaternion.Euler(0,0,rotZ);
        
    }
}
