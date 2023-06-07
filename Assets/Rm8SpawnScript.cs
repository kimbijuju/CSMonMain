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
        

        if(player.transform.position.x>235 && player.transform.position.y>-9 && player.transform.position.y<-6.9){

        
            texterScript.playerPos.x=13.4f;
            texterScript.playerPos.y=-11.2f;
            texterScript.currLvlScene="Level9Room";
            texterScript.NumItems[3]++;
            SceneManager.LoadScene("Level9Room");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(32,40, PokeList.Room3CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
