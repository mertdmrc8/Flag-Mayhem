using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Camera mainCam;
    public Vector3 mousePos; 
    public float rotZ ;
    void Start()
    {
        mainCam =GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos =mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos-transform.position;
     //   Vector3 rotation2 = mousePos-transform.position;
        rotZ =Mathf.Atan2(rotation.y, rotation.x) * (Mathf.Rad2Deg );
    //   transform.position=rotation2;
      transform.rotation =Quaternion.Euler(0,0,rotZ);
        
    }
}
