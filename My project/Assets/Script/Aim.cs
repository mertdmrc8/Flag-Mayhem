using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Camera mainCam;
    public Vector3 mousePos;
    public float rotZ;
    public GameObject ArmR, ArmL;
    public GameObject cross;
    public GameObject Player;
    void Start()
    {
        mainCam = GameObject.Find("Camera").GetComponent<Camera>();
        cross = GameObject.Find("Aim");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        //   Vector3 rotation2 = mousePos-transform.position;
       
        //   transform.position=rotation2;


        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        //ArmR.transform.rotation=Quaternion.Euler(0,0,rotZ);
        //ArmL.transform.rotation = Quaternion.Euler(0, 0, rotZ);

        cross.transform.position = mousePos;
       
            rotZ = Mathf.Atan2(rotation.y, rotation.x) * (Mathf.Rad2Deg);
            ArmR.transform.position = mousePos;
            ArmL.transform.position = mousePos;
        
        if (mousePos.x<0)
        {
          Player.transform.eulerAngles = new Vector3(0, 180, 0); // Flipped
        }
        else if (mousePos.x > 0)
        {
            Player.transform.eulerAngles = new Vector3(0, 0, 0); // Flipped
        }
            
        


    }
}
