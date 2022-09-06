using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Camera mainCam;
    public Vector3 mousePos; 
    public float rotZ ;
    public GameObject ArmR, ArmL;
 
    public GameObject cross;
    public GameObject Player;
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
        cross.transform.position = mousePos;

        ArmR.transform.position = mousePos;
        ArmL.transform.position = mousePos;

        print(rotation);
        //if (ArmR.transform.position.x > 0)
        //{
        //    Player.transform.eulerAngles = new Vector3(0, 0, 0); // Flipped

        //}
        //else if (ArmR.transform.position.x > 0)
        //{
        //    Player.transform.eulerAngles = new Vector3(0, 180, 0); // Flipped

        //}

        if (rotation.x > 0)
        {
            Player.transform.eulerAngles = new Vector3(0, 0, 0); // Flipped

        }
        else if (rotation.x < 0)
        {
            Player.transform.eulerAngles = new Vector3(0, 180, 0); // Flipped

        }

    }
    //250>rot <-120
}
