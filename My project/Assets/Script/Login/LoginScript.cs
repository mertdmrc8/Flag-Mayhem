using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject Canvals;
     
    readonly string login_posturl = "http://localhost:8080/auth/Login";


      public void loginbutton(){
        GameObject cloneprefab = Instantiate(prefab, new Vector3(Canvals.transform.position.x, Canvals.transform.position.y, Canvals.transform.position.z), Quaternion.identity);

        cloneprefab.transform.eulerAngles = new Vector3(cloneprefab.transform.eulerAngles.x, cloneprefab.transform.eulerAngles.y, cloneprefab.transform.eulerAngles.z - 90f);
        cloneprefab.transform.parent = Canvals.transform;
        Text  email = GameObject.Find("Input1").GetComponent<Text>();
        Text  password = GameObject.Find("Input2").GetComponent<Text>();

        Button connection_button = cloneprefab.transform.GetChild(0).GetComponent<Button>();
        Button exit_button = cloneprefab.transform.GetChild(1).GetComponent<Button>();

        connection_button.onClick.AddListener(delegate
        {
            StartCoroutine(LoginPostRequest( email.text,password.text));
            //cevap a göre sahne yükle 
            //SceneManager.LoadScene(1);
        });
          exit_button.onClick.AddListener(delegate
        {
            Destroy(cloneprefab); 
        });



    }

        IEnumerator LoginPostRequest(string email, string password)
    {

        
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
 
        UnityWebRequest www = UnityWebRequest.Post(login_posturl,form);
        
       
        var operation =www.SendWebRequest();
        yield return operation;

        // while(!operation.isDone)
        //    await Task.Yield();

        if(www.result==UnityWebRequest.Result.Success){
            print("ifte");
            Debug.Log($"response: {www.downloadHandler.text}");
            //dynamic stuff = JsonConvert.DeserializeObject($"{www.downloadHandler.text}"); 
           // dynamic stuff  = JsonConvert.DeserializeObject( "{"+ "email"+ ":"  +"Postman"+ "}" );
            Data stuff = JsonConvert.DeserializeObject<Data>($"{www.downloadHandler.text}");
          
            if(stuff.OnLogin==true){ 
                PlayerProperties.id_=stuff.id;
                PlayerProperties.OnLogin_=true;
                PlayerProperties.nickname_=stuff.NickName;
                SceneManager.LoadScene(1);
             }
            else{
                print("login failed");
            }

           

        }
        else 
            Debug.Log("response failed");
        

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {

            print(www.error);
        }
    }

  
}
