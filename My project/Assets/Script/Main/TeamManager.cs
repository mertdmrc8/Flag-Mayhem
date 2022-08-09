using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public BaseManager Base_; 
    public Material Color;
    public List<Character_Controller> team_players;


    [SerializeField]
    public Image healthbar ;

    public string TeamName;
    void Start()
    {
        Base_= transform.GetChild(0).GetComponent<BaseManager>();
        TeamName=gameObject.name;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
