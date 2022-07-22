using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
     [SerializeField]
    private GameObject Rooms ;
    

    [SerializeField]
    private GameObject Canvals; 

    void Start(){
        GameObject Rooms_= Instantiate(Rooms,new Vector3(Canvals.transform.position.x, Canvals.transform.position.y, Canvals.transform.position.z),Quaternion.identity);
         Rooms_.transform.eulerAngles = new Vector3(Rooms_.transform.eulerAngles.x, Rooms_.transform.eulerAngles.y, Rooms_.transform.eulerAngles.z - 90f);
        Rooms_.transform.parent = Canvals.transform;
    }
}
