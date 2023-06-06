using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shitfordemoScript : MonoBehaviour
{
    public Sprite tonyPNG;
    // Start is called before the first frame update
    void Start()
    {
        texterScript.tonySprite=tonyPNG;

        texterScript.NumItems = new int[5];
        texterScript.NumItems[1]=1;
        texterScript.NumItems[4]=2;
        int lvl=100;
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Ruthie.hp*40, PokeList.Ruthie));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", 0, PokeList.Steven));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Steve.hp*100, PokeList.Steve));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Vanessa.hp*100, PokeList.Vanessa));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Vishwa.hp*100, PokeList.Vishwa));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Yunxin.hp*100, PokeList.Yunxin));

        texterScript.playerPos.x=194f;
        texterScript.playerPos.y=2f;

        texterScript.currLvlScene="Level8Room";

        SceneManager.LoadScene("Level8Room");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
