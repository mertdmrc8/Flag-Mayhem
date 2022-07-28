using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Manager/GameSettings")]
public class GameSettings : ScriptableObject
{



    [SerializeField]
    private string _gameVersion="0.0.0";
    public string GameVersion {get { return _gameVersion;}}

    [SerializeField]
    private  string _nicName ="Punfish"; 

    public string NicName{
         

         get{
            int value = Random.Range(0,9999);
            return _nicName = _nicName+value.ToString();
         }
    }






    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
