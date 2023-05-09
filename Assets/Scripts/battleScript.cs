using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battleScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    public Image playerHPBar;
    public Image enemyHPBar;

    public Text texter;
    public GameObject enemy;
    
    public Text playerHeader;
    public Text enemyHeader;

    public PokeList.CSMon playerMon;
    public PokeList.CSMon enemyMon;

    public static Queue<string> textList;

    public int currCSMon;
    public int currEnemyMon;
    
    //buttonStuff
    public int buttonNum;
    public GameObject runButton;
    public GameObject attackButton;
    public GameObject swapButton;
    public GameObject itemButton;

    public Sprite runOn;
    public Sprite runOff;

    public Sprite attackOn;
    public Sprite attackOff;
    public Sprite swapOn;
    public Sprite swapOff;
    public Sprite itemOn;
    public Sprite itemOff;

    public Color transCol;
    public Color showCol;
    public Color yellowCol;
    public Color grayCol;
    //switch CSMON stuff
    public GameObject[] swapButtons;
    public int swapNum;
    public GameObject swap1;
    public GameObject swap2;
    public GameObject swap3;
    public GameObject swap4;
    public GameObject swap5;
    public GameObject swap6;
    public GameObject selectSq;

    public int prevhp;

    // player and enemy statuses (buffs n stuff)
    public int[] pStatus;
    public int[] eStatus;

    public int playerDmg;
    public int enemyDmg;
    
    void Start()
    {
        //setup
        textList=new Queue<string>();
        currCSMon=0;
        currEnemyMon=0;
        while(PokeList.ObtainedList[currCSMon].currhp<=0){
            currCSMon++;
        }
        playerMon=PokeList.ObtainedList[currCSMon];
        enemyMon=PokeList.enemyList[currEnemyMon];
        textList.Enqueue("A battle has commenced!");
        textList.Enqueue("What will you do?");

        pStatus=new int[6];
        eStatus=new int[6];

        buttonNum=1;
        //hiding buttons
        transCol=new Color(1,1,1,0f);
        showCol=new Color(1,1,1,1f);
        yellowCol=new Color(1,0.95f, 0.03f, 0.6f);
        grayCol=new Color(0.5f,0.5f, 0.5f, 0.6f);

        attackButton.GetComponent<SpriteRenderer>().color=transCol;
        swapButton.GetComponent<SpriteRenderer>().color=transCol;
        runButton.GetComponent<SpriteRenderer>().color=transCol;
        itemButton.GetComponent<SpriteRenderer>().color=transCol;
        //hiding swap buttons
        
        swapNum=0;
        while(swapNum<PokeList.ObtainedList.Count && swapNum<6){
            swapNum++;
        }
        swapButtons= new GameObject[swapNum];
        for(int i=0; i<swapNum; i++){
            if(i==0)
                swapButtons[i]=swap1;
            else if(i==1)
                swapButtons[i]=swap2;
            else if(i==2)
                swapButtons[i]=swap3;
            else if(i==3)
                swapButtons[i]=swap4;
            else if(i==4)
                swapButtons[i]=swap5;
            else if(i==5)
                swapButtons[i]=swap6;

        }
        swapNum=1;
        
        swap1.GetComponent<SpriteRenderer>().color=transCol;
        swap2.GetComponent<SpriteRenderer>().color=transCol;
        swap3.GetComponent<SpriteRenderer>().color=transCol;
        swap4.GetComponent<SpriteRenderer>().color=transCol;
        swap5.GetComponent<SpriteRenderer>().color=transCol;
        swap6.GetComponent<SpriteRenderer>().color=transCol;
        selectSq.GetComponent<SpriteRenderer>().color=transCol;

        swap1.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[0].refMon.look;
        swap2.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[1].refMon.look;
        swap3.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[2].refMon.look;
        swap4.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[3].refMon.look;
        swap5.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[4].refMon.look;
        swap6.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[5].refMon.look;

        // Key for Status: [0,1,2,3,4,5]=[Byonguk Speed Buff, Andrew Speed Boost, Charging, Dmg reduc, Dmg Boost, Burning]
        // Dmg reduc: if 1, 50% decrease. if 2, 100% decrease 
        // Charging: if 1, charged, if 0, uncharged
        

        
        GetComponent<SpriteRenderer>().sprite=playerMon.refMon.look;
        enemy.GetComponent<SpriteRenderer>().sprite=enemyMon.refMon.look;
        enemyHeader.text=enemyMon.printHeader();
        enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
        playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
        playerHeader.text=playerMon.printHeader();
        
        
    }
    
    // Update is called once per frame
    
    void Update()
    {
       
       
       playerHeader.text=playerMon.printHeader();
       enemyHeader.text=enemyMon.printHeader();

       if(textList.Count>0){
            texter.text=textList.Peek();
            if(texter.text=="What will you do?"){
                //if player died at end of last round

                if(playerMon.currhp<=0){
                
                    textList.Enqueue(playerMon.refMon.name+" fainted!");
                    textList.Enqueue("Who will you swap to?");
                    textList.Dequeue();
                    
                }
                else{
                    attackButton.GetComponent<SpriteRenderer>().color=showCol;
                    swapButton.GetComponent<SpriteRenderer>().color=showCol;
                    runButton.GetComponent<SpriteRenderer>().color=showCol;
                    itemButton.GetComponent<SpriteRenderer>().color=showCol;
                
                    if(Input.GetKeyDown(KeyCode.A)){
                        buttonNum--;
                        if(buttonNum<0)
                            buttonNum=3;
                    }
                    else if(Input.GetKeyDown(KeyCode.D)){
                        buttonNum++;
                        if(buttonNum>3)
                            buttonNum=0;
                    }
                    //if run button is selected
                    if(buttonNum==0){
                        runButton.GetComponent<SpriteRenderer>().sprite=runOn;
                        attackButton.GetComponent<SpriteRenderer>().sprite=attackOff;
                        swapButton.GetComponent<SpriteRenderer>().sprite=swapOff;
                        itemButton.GetComponent<SpriteRenderer>().sprite=itemOff;
                    }
                    //if attack button is selected
                    else if(buttonNum==1){
                        runButton.GetComponent<SpriteRenderer>().sprite=runOff;
                        attackButton.GetComponent<SpriteRenderer>().sprite=attackOn;
                        swapButton.GetComponent<SpriteRenderer>().sprite=swapOff;
                        itemButton.GetComponent<SpriteRenderer>().sprite=itemOff;
                        if(Input.GetKeyDown("space")){
                        //deciding who attacks first
                            int pSpeed=playerMon.lvl()*playerMon.refMon.speed*(pStatus[0]+1)*(pStatus[1]+1);
                            if(playerMon.refMon==PokeList.Vishwa)
                                pSpeed=pSpeed*(1+(playerMon.totalHp()-playerMon.currhp)/playerMon.totalHp());
                            int eSpeed=enemyMon.lvl()*enemyMon.refMon.speed*(eStatus[0]+1)*(eStatus[1]+1);
                            if(enemyMon.refMon==PokeList.Vishwa)
                                eSpeed=eSpeed*(1+(enemyMon.totalHp()-enemyMon.currhp)/enemyMon.totalHp());
                                //player attacks first
                            if(pSpeed >= eSpeed){
                                textList.Enqueue("Your "+playerMon.refMon.name+" used "+playerMon.refMon.attkName+"! ");
                                playerDmg=damage(playerMon, enemyMon, textList, pStatus, eStatus);
                                enemyMon.currhp-=playerDmg;


                                
                                if(enemyMon.currhp>=0){
                                    textList.Enqueue("Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! ");
                                    enemyDmg=damage(enemyMon, playerMon, textList, eStatus, pStatus);
                                    playerMon.currhp-=enemyDmg;
                                    //if enemyMon killed us after our turn
                                    if(playerMon.currhp<=0){
                                        textList.Enqueue("Your "+playerMon.refMon.name+" fainted!");
                                    
                                        bool anyLeft=false;
                                        
                                        for(int i=0; i<swapButtons.Length; i++){
                                            if(PokeList.ObtainedList[i].currhp>0){
                                                anyLeft=true;
                                                break;
                                            }
                                        }
                                        
                                    
                                        if(anyLeft==true){
                                            textList.Enqueue("Who will you swap to?");
                                        }
                                        else{
                                            textList.Enqueue("You have no healthy CSMon left!");
                                            textList.Enqueue("You lose this battle!");
                                        }
                                    }
                                    else
                                        textList.Enqueue("What will you do?");
                                    

                                }
                                //enemy died before it could attack
                                else{
                                    textList.Enqueue("Their "+enemyMon.refMon.name+" fainted!");
                                    textList.Enqueue("Your team of CSMon gained XP!");
                                    //gaining exp
                                    for(int i=0; i<swapButtons.Length; i++){
                                        double xpGain=3.0* (enemyMon.lvl())/PokeList.ObtainedList[i].lvl();
                                        PokeList.ObtainedList[i].exp+=xpGain;
                                        if(PokeList.ObtainedList[i].exp>100)
                                                PokeList.ObtainedList[i].exp=100;
                                    }
                                    currEnemyMon++;
                                    //no more enemies
                                    
                                    if(PokeList.enemyList[currEnemyMon]==null){
                                        textList.Enqueue("You win this battle!");
                                    }
                                    //more enemies
                                    else{
                                        textList.Enqueue("The enemy sent out "+PokeList.enemyList[currEnemyMon].refMon.name+"! ");
                                        textList.Enqueue("What will you do?");
                                    }
                                    
                                }
                        
                            }
                            else{
                                textList.Enqueue("Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! ");
                                enemyDmg=damage(enemyMon, playerMon, textList, eStatus, pStatus);
                                playerMon.currhp-=enemyDmg;
                                if(playerMon.currhp>=0){
                                    textList.Enqueue("Your "+playerMon.refMon.name+" used "+playerMon.refMon.attkName+"! ");
                                    playerDmg=damage(playerMon, enemyMon, textList, pStatus, eStatus);
                                    enemyMon.currhp-=playerDmg;
                                    //enemy died even though it went first
                                    if(enemyMon.currhp<=0){
                                        textList.Enqueue("Their "+enemyMon.refMon.name+" fainted!");
                                        textList.Enqueue("Your team of CSMon gained XP!");
                                        //gaining exp
                                        
                                        for(int i=0; i<swapButtons.Length; i++){
                                            double xpGain=3.0* (enemyMon.lvl())/PokeList.ObtainedList[i].lvl();
                                            PokeList.ObtainedList[i].exp+=xpGain;
                                            if(PokeList.ObtainedList[i].exp>100)
                                                PokeList.ObtainedList[i].exp=100;
                                        }
                                        
                                        currEnemyMon++;
                                        //no more enemies
                                    
                                        if(PokeList.enemyList[currEnemyMon]==null){
                                            textList.Enqueue("You win this battle!");
                                        }
                                        //more enemies
                                        else{
                                            textList.Enqueue("The enemy sent out "+PokeList.enemyList[currEnemyMon].refMon.name+"! ");
                                            textList.Enqueue("What will you do?");
                                        }
                                    }
                                    else
                                        textList.Enqueue("What will you do?");
                                }
                                //ally died before it could attack
                                else{
                                    textList.Enqueue("Your "+playerMon.refMon.name+" fainted!");
                                    
                                    bool anyLeft=false;
                                    for(int i=0; i<swapButtons.Length; i++){
                                        if(PokeList.ObtainedList[i].currhp>0){
                                            anyLeft=true;
                                            break;
                                        }
                                    }
                                    
                                    if(anyLeft==true){
                                        textList.Enqueue("Who will you swap to?");
                                    }
                                    else{
                                        textList.Enqueue("You have no healthy CSMon left!");
                                        textList.Enqueue("You lose this battle!");
                                    }
                                }
                            }
                            //end of round stuff
                            //if burning
                            /*
                            if(pStatus[5]>0){
                                textList.Enqueue("Your "+playerMon.refMon.name+" is burning!");
                                pStatus[5]--;
                            }
                            if(eStatus[5]>0){
                                textList.Enqueue("Their "+enemyMon.refMon.name+" is burning!");
                                eStatus[5]--;
                            }
                            */




                            attackButton.GetComponent<SpriteRenderer>().color=transCol;
                            swapButton.GetComponent<SpriteRenderer>().color=transCol;
                            runButton.GetComponent<SpriteRenderer>().color=transCol;
                            itemButton.GetComponent<SpriteRenderer>().color=transCol;
                    
                        }
                    }
                    //if swap button is selected
                    else if(buttonNum==2){
                        runButton.GetComponent<SpriteRenderer>().sprite=runOff;
                        attackButton.GetComponent<SpriteRenderer>().sprite=attackOff;
                        swapButton.GetComponent<SpriteRenderer>().sprite=swapOn;
                        itemButton.GetComponent<SpriteRenderer>().sprite=itemOff;
                        if(Input.GetKeyDown("space")){
                            textList.Enqueue("Who will you swap to?");
                            attackButton.GetComponent<SpriteRenderer>().color=transCol;
                            swapButton.GetComponent<SpriteRenderer>().color=transCol;
                            runButton.GetComponent<SpriteRenderer>().color=transCol;
                            itemButton.GetComponent<SpriteRenderer>().color=transCol;
                        
                        }

                    }
                    else if(buttonNum==3){
                        runButton.GetComponent<SpriteRenderer>().sprite=runOff;
                        attackButton.GetComponent<SpriteRenderer>().sprite=attackOff;
                        swapButton.GetComponent<SpriteRenderer>().sprite=swapOff;
                        itemButton.GetComponent<SpriteRenderer>().sprite=itemOn;
                    }
                }
            }
            else if(texter.text=="Who will you swap to?"){
                foreach(GameObject i in swapButtons){
                    i.GetComponent<SpriteRenderer>().color=showCol;
                }
                
                selectSq.GetComponent<SpriteRenderer>().color=yellowCol;

                if(PokeList.ObtainedList[swapNum].currhp<=0)
                    selectSq.GetComponent<SpriteRenderer>().color=grayCol;

                if(Input.GetKeyDown(KeyCode.A)){
                    swapNum--;
                    if(swapNum<0)
                        swapNum=swapButtons.Length-1;
                }

                else if(Input.GetKeyDown(KeyCode.D)){
                    swapNum++;
                    if(swapNum>swapButtons.Length-1)
                        swapNum=0;
                }
                //choose a CSMon to swap to
                else if(Input.GetKeyDown("space")){
                
                    if(PokeList.ObtainedList[swapNum].currhp<=0){
                        textList.Enqueue("You can't swap with them!");
                        textList.Enqueue("Who will you swap to?");
                    }
                    else if(swapNum==currCSMon)
                        textList.Enqueue("What will you do?");
                    
                    else{
                    //if swaps successfully
                        textList.Enqueue(PokeList.ObtainedList[swapNum].refMon.name+", I choose you!");

                        playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
                        for(int i=1; i<=5; i++)
                            pStatus[i]=0;
                        //prevhp makes updating health bars easier
                        prevhp=PokeList.ObtainedList[swapNum].currhp;
                        if(playerMon.currhp>0){
                            textList.Enqueue("Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! ");
                            enemyDmg=damage(enemyMon, PokeList.ObtainedList[swapNum], textList, eStatus, pStatus);
                            
                            PokeList.ObtainedList[swapNum].currhp-=enemyDmg;
                            
                        }
                        else
                            
                      
                        currCSMon=swapNum;

                        textList.Enqueue("What will you do?");
                    }  
                    foreach(GameObject i in swapButtons){
                        i.GetComponent<SpriteRenderer>().color=transCol;
                    }
                    selectSq.GetComponent<SpriteRenderer>().color=transCol;
                }
                   //resetting statuses
                   
                   
                 
                        
                
                if(swapNum==0){
                    selectSq.transform.position=swap1.transform.position;
                    
                }
                else if(swapNum==1){
                    selectSq.transform.position=swap2.transform.position;
                    
                    
                }
                else if(swapNum==2){
                    selectSq.transform.position=swap3.transform.position;
                    
                }
                else if(swapNum==3){
                    selectSq.transform.position=swap4.transform.position;
                    
                }
                else if(swapNum==4){
                    selectSq.transform.position=swap5.transform.position;
                    
                }
                else if(swapNum==5){
                    selectSq.transform.position=swap6.transform.position;
                    
                }
                

            }
            //update health bars after normal attacks
            else if(texter.text=="Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! "){
                if(Input.GetKeyDown("space"))
                    playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
            }

            else if(texter.text=="Your "+playerMon.refMon.name+" used "+playerMon.refMon.attkName+"! "){
                if(Input.GetKeyDown("space"))
                    enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
            }
            
            //else if(texter.text=="Your "+playerMon.refMon.name+" is burning!")

            
            else if(texter.text==PokeList.ObtainedList[swapNum].refMon.name+", I choose you!"){
                playerHPBar.rectTransform.sizeDelta= new Vector2(225*prevhp/playerMon.totalHp(), 25);
                currCSMon=swapNum;
                playerMon=PokeList.ObtainedList[currCSMon];
                GetComponent<SpriteRenderer>().sprite=playerMon.refMon.look;
            }
            else if(texter.text=="The enemy sent out "+PokeList.enemyList[currEnemyMon].refMon.name+"! "){
                enemyMon=PokeList.enemyList[currEnemyMon];
                enemy.GetComponent<SpriteRenderer>().sprite=enemyMon.refMon.look;
                enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
            }

           
            if(Input.GetKeyDown("space")){
                textList.Dequeue();
            }
        }
        
    }
    
    

    


//method for calculating damage, a is attacker, d is defender 
    public static int damage(PokeList.CSMon a, PokeList.CSMon d, Queue<string> t, int[] s, int[] e){
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
                t.Enqueue("It landed!");
            //checks dmg change due to type advantage
            
                if((a.refMon.type=="Fire" && d.refMon.type=="Grass") || (a.refMon.type=="Grass" && d.refMon.type=="Water") || (a.refMon.type=="Water" && d.refMon.type=="Fire")){
                    res*=3;
                    res/=2;
                    t.Enqueue("It was super effective!");
                }
                else if((a.refMon.type=="Fire" && d.refMon.type=="Water") || (a.refMon.type=="Grass" && d.refMon.type=="Fire") || (a.refMon.type=="Water" && d.refMon.type=="Grass")){
                    res/=2;
                    t.Enqueue("It wasn't very effective...");
                }
            //checks dmg change due to crit
                dice=Random.Range(0, 101);
                if(dice<a.refMon.critChance){
                    if(a.refMon==PokeList.Mehki){
                        res*=2;
                        t.Enqueue("Critical Hit!");
                    }
                    else if(a.refMon==PokeList.Bennet){
                        t.Enqueue("Critical Hit!");
                        t.Enqueue(d.refMon.name+ " got burnt!");
                        e[5]+=3;
                    }
                    else{
                        res*=3;
                        res/=2;
                        t.Enqueue("Critical Hit!");
                    }
                }
                if(s[3]==1){
                    s[3]=0;
                    t.Enqueue(a.refMon.name+" was milk'd on! "+a.refMon.name+"'s damage went down");
                    res/=2;
                }
            //checks to see damage change due to specific CSMon
                
                if(a.refMon==PokeList.Andrew){
                    t.Enqueue("Andrew is speeding up!");
                    s[1]++;
                }
                else if(a.refMon==PokeList.Byeongguk){
                    t.Enqueue("Byeongguk's whole team is speeding up!");
                    s[0]++;
                }
                else if(a.refMon==PokeList.Steven)
                    res*=(1+ (a.currhp)/a.totalHp());
                else if(a.refMon==PokeList.Catherine){
                    s[4]++;
                    t.Enqueue("Catherine's damage went up!");
                }
                else if(a.refMon==PokeList.Yunxin){
                    
                    e[3]=2;
                }
                else if(a.refMon==PokeList.Caleb){
                    
                    e[3]=1;
                }
                else if(a.refMon==PokeList.Peter || a.refMon==PokeList.Vanessa)
                    e[2]=0;
            }
                

        
                
                
            
            
            else{
                t.Enqueue("It missed!");
                return 0;
            }

        }
        return res;
    }

    
}

