
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.Networking;

public class Network : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    readonly string login_posturl = "http://localhost:8080/auth/Login";
    readonly string signin_posturl = "http://localhost:8080/auth/sign-in";

    //odalara istek at 

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        Debug.Log("lobiye girlidi");

        PhotonNetwork.JoinOrCreateRoom("oda", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true }, TypedLobby.Default);

   
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("odaya girildi");
        GameObject Player = PhotonNetwork.Instantiate("Ordinary", Vector3.zero, Quaternion.identity, 0, null) as GameObject;
        //GameObject Flag = GameObject.Find("Flag");
        //Flag.transform.parent = Player.transform;

        GameObject Bullet = PhotonNetwork.Instantiate("Bullet", Vector3.zero, Quaternion.identity, 0, null);
    }

    
    void Update()
    {

    }




}
