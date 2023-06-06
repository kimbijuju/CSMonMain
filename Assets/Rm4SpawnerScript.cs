using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rm4SpawnerScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Update()
    {

        if(player.transform.position.x>1.6 && player.transform.position.x<3.6 && player.transform.position.y>15){

        
            texterScript.playerPos.x=-4.2f;
            texterScript.playerPos.y=-1.1f;
            texterScript.currLvlScene="Level4Room";
            SceneManager.LoadScene("Level4Room");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(15,18, PokeList.Room2CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
