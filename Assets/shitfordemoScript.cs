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
        int lvl=100;
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Ruthie.hp*100, PokeList.Ruthie));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Steven.hp*100, PokeList.Steven));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Steve.hp*100, PokeList.Steve));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Vanessa.hp*100, PokeList.Vanessa));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Vishwa.hp*100, PokeList.Vishwa));
        PokeList.ObtainedList.Add(new PokeList.CSMon(lvl, "", PokeList.Yunxin.hp*100, PokeList.Yunxin));

        texterScript.playerPos.x=-6f;
        texterScript.playerPos.y=-1f;

        texterScript.currLvlScene="Level9Room";

        SceneManager.LoadScene("Level9Room");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
