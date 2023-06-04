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
        if(player.transform.position.x>9 && player.transform.position.x<15 ){
            texterScript.playerPos.x=40f;
            texterScript.playerPos.y=3f;
            
            SceneManager.LoadScene("Challenged Scene");
            
        }
        else if(player.transform.position.x>190 && player.transform.position.y>14 ){
            
            
            SceneManager.LoadScene("BossSpeech");
            
        }
    }
}
