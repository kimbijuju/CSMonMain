using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rm9SpawnerScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x>47 && player.transform.position.y>-7.7 && player.transform.position.y<-5.2){

        
            texterScript.playerPos.x=-31f;
            texterScript.playerPos.y=4f;
            texterScript.currLvlScene="Level10Room Remake";
            texterScript.NumItems[4]++;
            SceneManager.LoadScene("Level10Room Remake");
        } 
        else if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            if(Random.Range(0,10)>7){
                spawnScript.spawnBattle(100,100, PokeList.LegendaryCSMon);
            }
            else{
                spawnScript.spawnBattle(40,50, PokeList.Room9CSMon);
            }
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
