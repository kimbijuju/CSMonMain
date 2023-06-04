using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class challengedScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            int i=0;
            while(i<6){
                int r= Random.Range(0, 29);
                if(r!=6 && r!=8){
                    PokeList.CSMonRef refMon= PokeList.allList[r].refMon;
                    PokeList.enemyList.Add(new PokeList.CSMon(50, "", refMon.hp*50, refMon));
                    i++;
                    
                }
            }
            SceneManager.LoadScene("DemoBattleRoom");
        }
    }
}
