using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room1SpawnerScript : MonoBehaviour
{
    public GameObject player;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
    /*
        timer++;
        if(timer>=600){
            spawnScript.spawnBattle(1,4, PokeList.Room1CSMon);
            //SceneManager.LoadScene("DemoBattleRoom");
        }
        */
        if(player.transform.position.x>41.44 && player.transform.position.y>14){
            texterScript.playerPos.x=-6f;
            texterScript.playerPos.y=-1f;
            texterScript.currLvlScene="Level2Room";
            SceneManager.LoadScene("Level2Room");
            
        }
            

    }
}
