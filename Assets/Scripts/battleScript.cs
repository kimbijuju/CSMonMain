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

    // player and enemy statuses (buffs n stuff)
    public int[] pStatus;
    public int[] eStatus;

    public int playerDmg;
    public int enemyDmg;
    
    void Start()
    {
        //setup
        textList=new Queue<string>();
        playerMon=PokeList.ObtainedList[0];
        enemyMon=PokeList.enemyList[0];
        textList.Enqueue("A battle has commenced!");
        textList.Enqueue("What will you do?");

        pStatus=new int[6];
        eStatus=new int[6];
        // Key for Status: [0,1,2,3,4,5]=[Byonguk Speed Buff, Andrew Speed Boost, Charging, Dmg reduc, Dmg Boost, Burning]
        // Dmg reduc: if 1, 50% decrease. if 2, 100% decrease 
        // Charging: if 1, charged, if 0, uncharged
        

        
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
            if(texter.text=="What will you do?"){
                if(Input.GetKeyDown("space")){
                    //deciding who attacks first
                    if((playerMon.lvl()*playerMon.refMon.speed*(pStatus[0]+1)*(pStatus[1]+1)) >= (enemyMon.lvl()*enemyMon.refMon.speed*(eStatus[0]+1)*(eStatus[1]+1))){
                        textList.Enqueue(playerMon.refMon.name+" used "+playerMon.refMon.attkName+"!");
                        //dealing dmg
                        playerDmg=damage(playerMon, enemyMon, textList, pStatus);
                        enemyMon.currhp-=playerDmg;
                        enemyHeader.text=enemyMon.printHeader()+enemyMon.currhp+"/"+enemyMon.totalHp();
                        
                    }
                }
            }
            if(Input.GetKeyDown("space")){
                textList.Dequeue();
            }
        }
        
    }




    //method for calculating damage, a is attacker, d is defender 
    public static int damage(PokeList.CSMon a, PokeList.CSMon d, Queue<string> t, int[] s){
        int res=0;
        //if CSMon is hacked
        if(s[3]==2){
            s[3]=0;
            t.Enqueue(a.refMon.name+" was hacked! "+a.refMon.name+" can't attack!");
            return res;

        }
        // if CSMon has to charge up
        else if((a.refMon==PokeList.Vanessa || a.refMon==PokeList.Peter) && s[2]==0){
            s[2]=1;
            t.Enqueue(a.refMon.name+" is charging up!");
            return res;
        }
        else{
            //checks to see if move will move land
            int dice=Random.Range(0, 101);
            if(d.refMon==PokeList.Ruthie)
                dice*=2;
            if(dice<a.refMon.acc){
                res=a.refMon.attk*a.lvl();
            //checks dmg change due to type advantage
                if((a.refMon.type=="fire" && d.refMon.type=="grass") || (a.refMon.type=="grass" && d.refMon.type=="water") || (a.refMon.type=="water" && d.refMon.type=="fire")){
                    res*=3/2;
                    t.Enqueue("It was super effective!");
                }
                else if((a.refMon.type=="fire" && d.refMon.type=="water") || (a.refMon.type=="grass" && d.refMon.type=="fire") || (a.refMon.type=="water" && d.refMon.type=="grass")){
                    res/=2;
                    t.Enqueue("It wasn't very effective...");
                }
            //checks dmg change due to crit
                dice=Random.Range(0, 101);
                if(dice<a.refMon.critChance){
                    res*=3/2;
                    t.Enqueue("Critical Hit!");
                }
            //checks to see damage change due to specific CSMon
                if(a.refMon==PokeList.Andrew)
                    s[1]++;
                else if(a.refMon==PokeList.Byeongguk)
                    s[0]++;
                else if(a.refMon==PokeList.Steven)
                    res*=(1+ (a.currhp)/a.totalHp());
                else if(a.refMon==PokeList.Catherine){
                    s[4]++;
                    t.Enqueue(a.refMon.name+"'s damage went up");
                }
            
            }
            else{
                t.Enqueue("It missed!");
                return res;
            }

        }
        return res;
    }


}
