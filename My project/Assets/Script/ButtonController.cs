using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour
{ 
 

    [SerializeField]
    private GameObject authenticationPrefab; 

     [SerializeField]
    private GameObject Canvals ; 
     
    void Start()
    {
        
    }
 
    void Update()
    {
        
    }


    public void startbutton(){
        SceneManager.LoadScene(1);
    }

    public void quitbutton(){
      Application.Quit();
    }

    public void loginbutton(){ 
    Authentication();


    }

    public void signinbutton(){  
    Authentication();
    }  


  //   public void connection_button_onclick(){ 

  //     }

  //    public void exit_button_onclick(){ 

  // }
    
  private void Authentication(){

    GameObject cloneprefab= Instantiate(authenticationPrefab, new Vector3(Canvals.transform.position.x, Canvals.transform.position.y, Canvals.transform.position.z), Quaternion.identity);
     
    cloneprefab.transform.eulerAngles=  new Vector3(cloneprefab.transform.eulerAngles.x,cloneprefab.transform.eulerAngles.y,cloneprefab.transform.eulerAngles.z-90f);
    
    
    
    cloneprefab.transform.parent = Canvals.transform;   

    Button connection_button =cloneprefab.transform.GetChild(0).GetComponent<Button>(); 
    Button exit_button  =     cloneprefab.transform.GetChild(1).GetComponent<Button>();

    connection_button.onClick.AddListener(delegate { 
      

       });

    exit_button.onClick.AddListener(delegate { 
       Destroy(cloneprefab);


       });
  }






}
