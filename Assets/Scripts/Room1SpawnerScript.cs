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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x>41.44 && player.transform.position.y>14){
            texterScript.playerPos.x=-6f;
            texterScript.playerPos.y=-1f;

            SceneManager.LoadScene("Level2Room");
        }
        else if(PlayerController.touchingGrass){
            if (Random.Range(1, 101) <= 10){
            
                spawnScript.spawnBattle(1,4, PokeList.Room1CSMon);
                SceneManager.LoadScene("DemoBattleRoom");
            }
        }

        
            

    }
}
