using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class demoPrepScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PokeList.ObtainedList.Add(new PokeList.CSMon(100, "", (PokeList.Krish.hp)*100, PokeList.Krish));

        PokeList.ObtainedList.Add(new PokeList.CSMon(100, "", (PokeList.Evan.hp)*100, PokeList.Evan));
        //PokeList.ObtainedList.Add(new PokeList.CSMon(100, "", (PokeList.Bijou.hp)*100, PokeList.Bijou));
        
        //PokeList.ObtainedList.Add(new PokeList.CSMon(100, "", (PokeList.Peter.hp)*100, PokeList.Peter));
        //PokeList.ObtainedList.Add(new PokeList.CSMon(100, "", (PokeList.Steve.hp)*100, PokeList.Steve));
        //PokeList.ObtainedList.Add(new PokeList.CSMon(100, "", (PokeList.Derrick.hp)*100, PokeList.Derrick));
        //PokeList.ObtainedList.Add(new PokeList.CSMon(100, "", (PokeList.Emily.hp)*100, PokeList.Emily));

        PokeList.enemyList.Add(new PokeList.CSMon(100, "", (PokeList.Steve.hp)*100, PokeList.Steve));
        PokeList.enemyList.Add(new PokeList.CSMon(100, "", (PokeList.Derrick.hp)*100, PokeList.Derrick));
        

        SceneManager.LoadScene("DemoBattleRoom");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
