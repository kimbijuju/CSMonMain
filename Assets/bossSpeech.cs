 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bossSpeech : MonoBehaviour
{
    public Queue<string> tList;
    public Text texter;
    public float cVal;

    // Start is called before the first frame update
    void Start()
    {
        cVal=0f;
        tList=new Queue<string>();
        tList.Enqueue("Well, Well, Well...");
        tList.Enqueue("I see that you've become a fine Master at Computer Science");
        tList.Enqueue("To think that you managed to create such a strong team of CS'Mon after choosing "+texterScript.starterString+" as your starter...");
        tList.Enqueue("Oh well, let's see just how much you've grown!");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cVal<1f){
            cVal+=0.005f;
            GetComponent<SpriteRenderer>().color=new Color(cVal,cVal,cVal,1);;
        }
        else if(tList.Count>0){
            texter.text=tList.Peek();
            if(Input.GetKeyDown("space")){
                tList.Dequeue();
                if(texter.text=="Oh well, let's see just how much you've grown!"){
                    PokeList.enemyList.Add(new PokeList.CSMon(70, "", PokeList.Robert.hp*70, PokeList.Robert));
                    PokeList.enemyList.Add(new PokeList.CSMon(70, "", PokeList.Doran.hp*70, PokeList.Doran));
                    PokeList.enemyList.Add(new PokeList.CSMon(70, "", PokeList.Tate.hp*70, PokeList.Tate));
                    PokeList.enemyList.Add(new PokeList.CSMon(70, "", PokeList.Yang.hp*70, PokeList.Yang));

                    texterScript.currLvlScene="CreditsScene";
                    SceneManager.LoadScene("DemoBattleRoom");
                }
            }
        }
    }
}
