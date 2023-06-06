using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rm6SpawnScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        

        if(player.transform.position.x>48 && player.transform.position.y>-3.6 && player.transform.position.y<-1.2){

        
            texterScript.playerPos.x=-49.7f;
            texterScript.playerPos.y=8.7f;
            texterScript.currLvlScene="Level7Room";
            texterScript.NumItems[1]+=2;
            SceneManager.LoadScene("Level7Room");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(21,25, PokeList.Room3CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
