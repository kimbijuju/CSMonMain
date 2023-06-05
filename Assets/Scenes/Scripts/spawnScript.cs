 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    public static void spawnBattle(int minLvl, int maxLvl, List<PokeList.CSMonRef> wildCSMon){
        PokeList.CSMonRef refMon= wildCSMon[Random.Range(0, wildCSMon.Count)];
        int lvl=Random.Range(minLvl, maxLvl);
        PokeList.enemyList.Add(new PokeList.CSMon(lvl, "", refMon.hp*lvl, refMon));
    }
}
