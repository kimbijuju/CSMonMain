using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room2SpawnerScript : MonoBehaviour
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

        if(player.transform.position.x>44.4 && player.transform.position.y>14){

        
            texterScript.playerPos.x=-6.7f;
            texterScript.playerPos.y=-0.8f;
            texterScript.currLvlScene="Level3Room";
            SceneManager.LoadScene("Level3Room");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(7,10, PokeList.Room1CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
