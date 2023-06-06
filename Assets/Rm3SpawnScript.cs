using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rm3SpawnScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(player.transform.position.x<-21 && player.transform.position.y>15.5){

        
            texterScript.playerPos.x=-7.1f;
            texterScript.playerPos.y=-1.7f;
            texterScript.currLvlScene="Level4Room";
            texterScript.NumItems[1]++;
            SceneManager.LoadScene("Level4Room");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(12,15, PokeList.Room2CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
