using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room2SpawnerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        texterScript.currLvlScene="Level2Room";
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if(timer>=600){
            spawnScript.spawnBattle(5,11, PokeList.Room1CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }

        //if(player.transform.position.x>6)
            //SceneManager.LoadScene("Level3Room");

    }
}
