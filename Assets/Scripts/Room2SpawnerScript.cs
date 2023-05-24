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

        
           SceneManager.LoadScene("Room10");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(6,10, PokeList.Room2CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
