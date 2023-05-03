using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class demoBattleScript : MonoBehaviour
    
{
    // Start is called before the first frame update
    public GameObject enemyMon;
    public Text enemyHeader;
    public Text playerHeader;
    void Start()
    {
        //setup

        GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[0].refMon.look;
        enemyMon.GetComponent<SpriteRenderer>().sprite=PokeList.enemyList[0].refMon.look;
        enemyHeader.text=PokeList.enemyList[0].printHeader();
        playerHeader.text=PokeList.ObtainedList[0].printHeader();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){
            PokeList.ObtainedList.Add(PokeList.enemyList[0]);
            PokeList.enemyList=new List<PokeList.CSMon>();
            SceneManager.LoadScene(texterScript.currLvlScene);
        }
    }
}
