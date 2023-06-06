using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rm5SpawnScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Update()
    {
        

        if(player.transform.position.x>17.7 && player.transform.position.x<21.1 && player.transform.position.y>-10 && player.transform.position.y<-7){

        
            texterScript.playerPos.x=-4.2f;
            texterScript.playerPos.y=-1.1f;
            texterScript.currLvlScene="Level4Room";
            SceneManager.LoadScene("Level4Room");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(18,21, PokeList.Room3CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
