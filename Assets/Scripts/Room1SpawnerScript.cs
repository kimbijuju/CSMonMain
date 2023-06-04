using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room1SpawnerScript : MonoBehaviour
{
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(player.transform.position.x>41.44 && player.transform.position.y>14){
            texterScript.playerPos.x=-6f;
            texterScript.playerPos.y=-1f;
            texterScript.currLvlScene="Level2Room";
            SceneManager.LoadScene("Level2Room");
            
        }
         
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(3,7, PokeList.Room1CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }

    }
}
