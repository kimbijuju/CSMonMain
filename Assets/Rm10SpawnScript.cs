using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rm10SpawnScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x>-22 && player.transform.position.x<-20 ){
            texterScript.playerPos.x=-14f;
            texterScript.playerPos.y=4.5f;
            
            SceneManager.LoadScene("Challenged Scene");
            
        }
        else if(player.transform.position.x>35.28 && player.transform.position.x<42.28 && player.transform.position.y>-9.3 && player.transform.position.y<-3.6){
            
            
            SceneManager.LoadScene("BossSpeech");
            
        }
    }
}
