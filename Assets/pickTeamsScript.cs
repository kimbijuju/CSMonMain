using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickTeamsScript : MonoBehaviour
{
    public GameObject ytButton;
    public GameObject ttButton;
    public GameObject fightButton;

    public Sprite ytOn;
    public Sprite ytOff;
    public Sprite ttOn;
    public Sprite ttOff;
    public Sprite fightOn;
    public Sprite fightOff;

    public int buttonNum;
    // Start is called before the first frame update
    void Start()
    {
        buttonNum=0;
        texterScript.currLvlScene="pickScreen";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            buttonNum--;
            if(buttonNum<0)
                buttonNum=2;
        }

        else if(Input.GetKeyDown(KeyCode.D)){
            buttonNum++;
            if(buttonNum>2)
                buttonNum=0;
        }
        if(buttonNum==0){
            ytButton.GetComponent<SpriteRenderer>().sprite=ytOn;
            fightButton.GetComponent<SpriteRenderer>().sprite=fightOff;
            ttButton.GetComponent<SpriteRenderer>().sprite=ttOff;
            if(Input.GetKeyDown("space")){
                optionsScript.listOfMon=PokeList.allList;
                optionsScript.team=true;
                SceneManager.LoadScene("CSDex Scene");
            }
        }
        else if(buttonNum==1){
            ytButton.GetComponent<SpriteRenderer>().sprite=ytOff;
            fightButton.GetComponent<SpriteRenderer>().sprite=fightOn;
            ttButton.GetComponent<SpriteRenderer>().sprite=ttOff;
            if(Input.GetKeyDown("space")){
                foreach(PokeList.CSMon i in PokeList.allList)
                    PokeList.ObtainedList.Add(i);
                foreach(PokeList.CSMon i in PokeList.allEList)
                    PokeList.enemyList.Add(i);
                SceneManager.LoadScene("DemoBattleRoom");
            }
        }
        else if(buttonNum==2){
            ytButton.GetComponent<SpriteRenderer>().sprite=ytOff;
            fightButton.GetComponent<SpriteRenderer>().sprite=fightOff;
            ttButton.GetComponent<SpriteRenderer>().sprite=ttOn;
            if(Input.GetKeyDown("space")){
                optionsScript.listOfMon=PokeList.allEList;
                optionsScript.team=true;
                SceneManager.LoadScene("CSDex Scene");
            }
        }
    }
}
