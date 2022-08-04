using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    private BaseManager Base_;
 
    public Character_Controller Player;
    void Start()
    {
        Base_= transform.GetChild(0).GetComponent<BaseManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
