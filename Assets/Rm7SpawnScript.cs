using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rm7SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        

        if(player.transform.position.x>46.1 && player.transform.position.y<-20.3){

        
            texterScript.playerPos.x=194.8f;
            texterScript.playerPos.y=2.2f;
            texterScript.currLvlScene="Level8Room";
            texterScript.NumItems[2]+=2;
            SceneManager.LoadScene("Level8Room");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(25,32, PokeList.Room3CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
