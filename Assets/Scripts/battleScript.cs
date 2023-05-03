using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text texter;
    public GameObject enemy;
    
    public Text playerHeader;
    public Text enemyHeader;

    public PokeList.CSMon playerMon;
    public PokeList.CSMon enemyMon;

    public static Queue<string> textList;
    void Start()
    {
        textList=new Queue<string>();
        playerMon=PokeList.ObtainedList[0];
        enemyMon=PokeList.enemyList[0];
        textList.Enqueue("A battle has commenced!");
        
        GetComponent<SpriteRenderer>().sprite=playerMon.refMon.look;
        enemy.GetComponent<SpriteRenderer>().sprite=enemyMon.refMon.look;
        enemyHeader.text=enemyMon.printHeader()+enemyMon.currhp+"/"+enemyMon.totalHp();
        playerHeader.text=playerMon.printHeader()+playerMon.currhp+"/"+playerMon.totalHp();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(textList.Count>0){
            texter.text=textList.Peek();
        }
    }
}
