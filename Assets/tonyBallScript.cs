using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tonyBallScript : MonoBehaviour
{
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    public Sprite s7;
    public Sprite s8;
    public Sprite s9;
    public Sprite s10;
    public Sprite s11;

    public Sprite[] sList; 

    public int i;

    public Text texter;

    public Color showCol;
    public Color transCol;
    
    // Start is called before the first frame update
    void Start()
    {
        sList=new Sprite[11];
        sList[0]=s1;
        sList[1]=s2;
        sList[2]=s3;
        sList[3]=s4;
        sList[4]=s5;
        sList[5]=s6;
        sList[6]=s7;
        sList[7]=s8;
        sList[8]=s9;
        sList[9]=s10;
        sList[10]=s11;
        
        i=0;

        transCol=new Color(1,1,1,0f);
        showCol=new Color(1,1,1,1f);
        GetComponent<SpriteRenderer>().color=transCol;
    }

    // Update is called once per frame
    void Update()
    {
        if(i%3==0)
            GetComponent<SpriteRenderer>().sprite=sList[i/3];
        if(texter.text=="You used a CS'Ball!"){
            GetComponent<SpriteRenderer>().color=showCol;
            transform.position=new Vector2(-2,-2);
            i=0;
        }
        else if(texter.text=="*Roll*Roll*Roll..."){
            transform.position=new Vector2(4, 1.5f);
            i++;
            if(i>30)
                i=0;
        }
        else if(texter.text==battleScript.enemyMon.refMon.name+" broke free!"){
            GetComponent<SpriteRenderer>().color=transCol;
        }
        else if(texter.text=="You caught "+battleScript.enemyMon.refMon.name+"!"){
            i=0;
        }
        
        
    }
}
