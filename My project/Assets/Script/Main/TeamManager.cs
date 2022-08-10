using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public BaseManager Base_;
    public Material Color;
    public List<Character_Controller> team_players;


    [SerializeField]
    public Image healthbar;

    public string TeamName;
    void Start()
    {
        Base_ = transform.GetChild(0).GetComponent<BaseManager>();
        TeamName = gameObject.name;

    }

   [PunRPC]
    public void PlayerSetBase(Character_Controller ordinary_ )
    {
        ordinary_.gameObject.SetActive(false);
        print(name +" aktif değil health 100");
        ordinary_.health=100;
        ordinary_.transform.position = Base_.gameObject.transform.position;
        ordinary_.gameObject.SetActive(true);

      //  StartCoroutine(wait(ordinary_));

    }

    IEnumerator wait(Character_Controller ordinary_){

        yield return new WaitForSeconds(1f);
        print(name +" aktif");

    }
}
