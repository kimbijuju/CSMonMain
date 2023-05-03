using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class demoPrepScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PokeList.ObtainedList.Add(new PokeList.CSMon(100, "", (PokeList.Bijou.hp)*100, PokeList.Bijou));
        PokeList.enemyList.Add(new PokeList.CSMon(100, "", (PokeList.Nilesh.hp)*100, PokeList.Nilesh));
        SceneManager.LoadScene("DemoBattleRoom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
