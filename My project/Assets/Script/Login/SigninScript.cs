using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SigninScript : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject Canvals;

    readonly string signin_posturl = "http://localhost:8080/auth/sign-in";

    public void signinbutton(){
        GameObject cloneprefab = Instantiate(prefab, new Vector3(Canvals.transform.position.x, Canvals.transform.position.y, Canvals.transform.position.z), Quaternion.identity);

        cloneprefab.transform.eulerAngles = new Vector3(cloneprefab.transform.eulerAngles.x, cloneprefab.transform.eulerAngles.y, cloneprefab.transform.eulerAngles.z - 90f);
        cloneprefab.transform.parent = Canvals.transform;
        Text  nick = GameObject.Find("Input0").GetComponent<Text>();
        Text  email = GameObject.Find("Input1").GetComponent<Text>();
        Text  password = GameObject.Find("Input2").GetComponent<Text>();

        Button connection_button = cloneprefab.transform.GetChild(0).GetComponent<Button>();
        Button exit_button = cloneprefab.transform.GetChild(1).GetComponent<Button>();


        connection_button.onClick.AddListener(delegate
        {
            StartCoroutine(SigninPostRequest(nick.text,email.text,password.text));

        });

          exit_button.onClick.AddListener(delegate
        {
            Destroy(cloneprefab); 
        });
    }


    IEnumerator SigninPostRequest(string nick,string email, string password)
    {
        WWWForm form = new WWWForm();
        print("sign in de ");
        form.AddField("nick", nick);
        form.AddField("email", email);
        form.AddField("password", password);
        print(signin_posturl);


        UnityWebRequest www = UnityWebRequest.Post(signin_posturl, form); 


        var operation =www.SendWebRequest();
        yield return operation;

        // while(!operation.isDone)
        //    await Task.Yield();

        if(www.result==UnityWebRequest.Result.Success){
            print("ifte");
            Debug.Log($"response: {www.downloadHandler.text}");
        }
        else
            Debug.Log("failed");
        
        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        { 
            print(www.error); 
        } 

    }


}
