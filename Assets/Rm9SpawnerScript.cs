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
        if(player.transform.position.x>48 ){

        
            texterScript.playerPos.x=-30f;
            texterScript.playerPos.y=-2f;
            texterScript.currLvlScene="Level10Room";
            SceneManager.LoadScene("Level10Room");
        } 
        if(PlayerController.spawnNow==true){
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
