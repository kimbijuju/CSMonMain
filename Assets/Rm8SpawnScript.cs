using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Rm8SpawnScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        

        if(player.transform.position.x>49.5 &&  player.transform.position.y<-23.8){

        
            texterScript.playerPos.x=-5f;
            texterScript.playerPos.y=2f;
            texterScript.currLvlScene="Level9Room remake";
            texterScript.NumItems[3]++;
            SceneManager.LoadScene("Level9Room remake");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(32,40, PokeList.Room3CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
