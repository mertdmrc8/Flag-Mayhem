using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
public class PlayersController : MonoBehaviour, IPunInstantiateMagicCallback
{
    public TeamManager TeamRed;
    public TeamManager TeamBlue;
    public GameObject players;
    public List<PhotonView> photonViews = new List<PhotonView>();


    void Start()
    {
        print("onjoined main");

        object[] PlayerData = {
             PlayerProperties.roomid_   };
        GameObject Gameob = PhotonNetwork.Instantiate("Ordinary", Vector3.zero, Quaternion.identity, 0, PlayerData);
        StartCoroutine(SetTeams());


    }

    IEnumerator SetTeams()
    {
        //ikinci oyuncunun da buraya girmesi için viewleri yakala

        yield return new WaitForSeconds(1);
        int i = 0;
        foreach (PhotonView item in photonViews)
        {
            print(i);

            item.gameObject.transform.parent = players.transform;
            i++;
        }
        yield return new WaitForSeconds(0.5f);
        for (int j = 0; j < PhotonNetwork.CurrentRoom.PlayerCount; j++)
        {
            foreach (Transform Ordinary in players.transform)
            {
                int Ordinary_id = Convert.ToInt32(Ordinary.gameObject.GetPhotonView().InstantiationData.GetValue(0));
                if (Ordinary_id == j)
                {
                    if (j % 2 == 0)
                    {
                        TeamManager team = TeamBlue;
                        Ordinary.transform.parent = team.transform;
                        Ordinary.GetComponent<Character_Controller>().Team = team;
                        team.team_players.Add(Ordinary.GetComponent<Character_Controller>());
                        Ordinary.transform.GetComponent<SpriteRenderer>().color = team.Color.color;
                    }
                    else
                    {
                        TeamManager team = TeamRed;
                        Ordinary.transform.parent = team.transform;
                        Ordinary.GetComponent<Character_Controller>().Team = team;
                        team.team_players.Add(Ordinary.GetComponent<Character_Controller>());
                        Ordinary.transform.GetComponent<SpriteRenderer>().color = team.Color.color;
                    }

                }

            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
    void IPunInstantiateMagicCallback.OnPhotonInstantiate(PhotonMessageInfo info)
    {

        print("OnPhotonInstantiate  de");
        object[] instantiationData = info.photonView.InstantiationData;
        print(instantiationData);
    }

}
