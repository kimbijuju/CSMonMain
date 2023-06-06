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
        

        if(player.transform.position.x>18 && player.transform.position.x<21 && player.transform.position.y>-7.4 && player.transform.position.y>-9){

        
            texterScript.playerPos.x=-6.7f;
            texterScript.playerPos.y=3f;
            texterScript.currLvlScene="Level6Room";
            texterScript.NumItems[2]++;
            SceneManager.LoadScene("Level6Room");
        } 
        if(PlayerController.spawnNow==true){
            PlayerController.spawnNow=false;
            spawnScript.spawnBattle(18,21, PokeList.Room3CSMon);
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
