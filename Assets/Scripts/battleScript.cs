using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class battleScript : MonoBehaviour
{
    //if battle over or not
    
    // Start is called before the first frame update
    public Image playerHPBar;
    public Image enemyHPBar;

    public Text texter;
    public GameObject enemy;
    
    public Text playerHeader;
    public Text enemyHeader;

    public PokeList.CSMon playerMon;
    public static PokeList.CSMon enemyMon;

    public int prevPlayerMon;
    public int prevEnemyMon;


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
    //effects
    public bool pBurning;
    public bool eBurning;

    public bool pEffect;
    public bool eEffect;
    
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
        

        pBurning =false;
        eBurning=false;
        pEffect=false;
        eEffect=false;
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
            if(i==0){
                swapButtons[i]=swap1;
                swap1.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[0].refMon.look;
            }
            else if(i==1){
                swapButtons[i]=swap2;
                swap2.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[1].refMon.look;
            }
            else if(i==2){
                swapButtons[i]=swap3;
                swap3.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[2].refMon.look;
            }
            else if(i==3){
                swapButtons[i]=swap4;
                swap4.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[3].refMon.look;
            }
            else if(i==4){
                swapButtons[i]=swap5;
                swap5.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[4].refMon.look;
            }
            else if(i==5){
                swapButtons[i]=swap6;
                swap6.GetComponent<SpriteRenderer>().sprite=PokeList.ObtainedList[5].refMon.look;
            }

        }
        swapNum=0;
        
        swap1.GetComponent<SpriteRenderer>().color=transCol;
        swap2.GetComponent<SpriteRenderer>().color=transCol;
        swap3.GetComponent<SpriteRenderer>().color=transCol;
        swap4.GetComponent<SpriteRenderer>().color=transCol;
        swap5.GetComponent<SpriteRenderer>().color=transCol;
        swap6.GetComponent<SpriteRenderer>().color=transCol;
        selectSq.GetComponent<SpriteRenderer>().color=transCol;

        
        
        
        
        
        

        // Key for Status: [0,1,2,3,4,5, 6]=[Byonguk Speed Buff, Andrew Speed Boost, Charging, Dmg reduc, Dmg Boost, Burning]
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
                


                //End of round stuff

                


                
                //if player is burning
                if(pBurning && pStatus[5]>0 && enemyDmg>0){
                    textList.Dequeue();
                    textList.Enqueue(playerMon.refMon.name+" is suffering from their burns!");
                    playerMon.currhp=playerMon.currhp-3*enemyDmg/10;
                    pStatus[5]--;


                    
                    playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
                    
                    textList.Enqueue("What will you do?");
                    pBurning=false;
                }
                //if enemy is burning
                else if(eBurning && playerDmg>0 && eStatus[5]>0){
                    textList.Dequeue();
                    textList.Enqueue(enemyMon.refMon.name+" is suffering from their burns!");
                    enemyMon.currhp=enemyMon.currhp-3*playerDmg/10;
                    eStatus[5]--;
                    
                    enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
                    
                    textList.Enqueue("What will you do?");
                    eBurning=false;
                }
                //if player mon has some end of round effects
                else if(pEffect){
                    textList.Dequeue();
                    if(playerDmg>0){
                        
                        if(PokeList.ObtainedList[prevPlayerMon].refMon==PokeList.Nilesh && playerMon.refMon==PokeList.Nilesh){
                        
                            textList.Enqueue("Nilesh suffered from recoil!");
                            
                            playerMon.currhp*=7;
                            playerMon.currhp/=10;
                            
                        }
                       
                        else if(((PokeList.ObtainedList[prevPlayerMon].refMon==PokeList.Steve && playerMon.refMon==PokeList.Steve) || (PokeList.ObtainedList[prevPlayerMon].refMon==PokeList.Daniel && playerMon.refMon==PokeList.Daniel)) && playerMon.currhp>0){
                            textList.Enqueue(playerMon.refMon.name+" healed up!");
                            int healAmount=playerDmg*7/10;
                            playerMon.currhp+=healAmount;
                            if(playerMon.currhp>playerMon.totalHp())
                                playerMon.currhp=playerMon.totalHp();
                            
                        }
                        
                            
                            
                            
                        
                        
                    }
                    if(enemyDmg>0){
                        if(playerMon==PokeList.ObtainedList[prevPlayerMon] && playerMon.refMon==PokeList.Grace){
                            textList.Enqueue("Grace redirected some damage!");
                            int damageTaken=enemyDmg*3/10;
                            enemyMon.currhp-=damageTaken; 
                        }
                    }
                    pEffect=false;
                    textList.Enqueue("What will you do?");
                    playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
                    enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
                    

                }
                
                
                    //if enemy mon has some end of round effects
                else if(eEffect==true){
                    textList.Dequeue();
                    if(enemyDmg>0){
                        
                        if(enemyMon.refMon==PokeList.Nilesh && PokeList.enemyList[prevEnemyMon].refMon==PokeList.Nilesh){
                        
                            textList.Enqueue("Nilesh suffered from recoil!");
                            enemyMon.currhp*=7;
                            enemyMon.currhp/=10;
                            
                        }
                        
                        else if(((PokeList.enemyList[prevEnemyMon].refMon==PokeList.Steve && enemyMon.refMon==PokeList.Steve) || (PokeList.enemyList[prevEnemyMon].refMon==PokeList.Daniel && enemyMon.refMon==PokeList.Daniel)) && enemyMon.currhp>0){
                            textList.Enqueue(enemyMon.refMon.name+" healed up!");
                            int healAmount=enemyDmg*7/10;
                            enemyMon.currhp+=healAmount;
                            if(enemyMon.currhp>enemyMon.totalHp())
                                enemyMon.currhp=enemyMon.totalHp();
                            
                        }
                        
                    }
                    if(playerDmg>0){
                        if(enemyMon==PokeList.enemyList[prevEnemyMon] && enemyMon.refMon==PokeList.Grace){
                            textList.Enqueue("Grace redirected some of "+playerMon.refMon.name+"'s damage!");
                            int damageTaken=playerDmg*3/10;
                            playerMon.currhp-=damageTaken; 
                        }    
                    }
                    eEffect=false;
                    textList.Enqueue("What will you do?");
                    playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
                    enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
                    
                }
                
                    
                    
                //if ally derrick can execute
                else if(playerMon.refMon==PokeList.Derrick && enemyMon.currhp>0 && enemyMon.currhp*4<enemyMon.totalHp()){
                    textList.Dequeue();
                    textList.Enqueue("Derrick cleared the enemy"+enemyMon.refMon.name+"'s line!");
                    textList.Enqueue("What will you do?");
                    enemyMon.currhp=0;
                    //enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
                    texter.text=textList.Peek();

                }  
                //if enemy derrick can execute
                else if(enemyMon.refMon==PokeList.Derrick && playerMon.currhp>0 && playerMon.currhp*4<playerMon.totalHp()){
                    textList.Dequeue();
                    textList.Enqueue("Derrick cleared your "+playerMon.refMon.name+"'s line!");
                    textList.Enqueue("What will you do?");
                    playerMon.currhp=0;
                    //playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
                    texter.text=textList.Peek();

                }   


                    
                    
                    //if anyone dies after end of round
                else if(playerMon.currhp<=0 || enemyMon.currhp<=0){
                    textList.Dequeue();    
                    //if enemy dies at end of round
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
                                    
                                    //no more enemies
                                    
                        if(PokeList.enemyList.Count<currEnemyMon+2){
                                        //you win
                            textList.Enqueue("You win this battle!");
                            
                                        
                        }
                                    //more enemies
                        else{
                            currEnemyMon++;
                            textList.Enqueue("The enemy sent out "+PokeList.enemyList[currEnemyMon].refMon.name+"! ");
                            
                            
                                
                        }
                    }
                    // if player dies at end of round
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
                                //you lose
                            
                            textList.Enqueue("You lose this battle!");
                            
                                        
                                        
                        }
                    }
                    texter.text=textList.Peek();

                    
                    
                   
                    
                }
               
                
                
                
                else{
                    playerDmg=0;
                    enemyDmg=0;
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
                        if(Input.GetKeyDown("space")){
                            textList.Enqueue("You ran away!");
                            attackButton.GetComponent<SpriteRenderer>().color=transCol;
                            swapButton.GetComponent<SpriteRenderer>().color=transCol;
                            runButton.GetComponent<SpriteRenderer>().color=transCol;
                            itemButton.GetComponent<SpriteRenderer>().color=transCol;
                        }
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
                                
                                //if enemy survived player attacking it first
                                if(enemyMon.currhp>0){
                                    textList.Enqueue("Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! ");
                                    enemyDmg=damage(enemyMon, playerMon, textList, eStatus, pStatus);
                                    playerMon.currhp-=enemyDmg;
                                }
                                    
                        
                            }
                            //enemy attacks first
                            else{
                                textList.Enqueue("Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! ");
                                enemyDmg=damage(enemyMon, playerMon, textList, eStatus, pStatus);
                                playerMon.currhp-=enemyDmg;
                                if(playerMon.currhp>0){
                                    textList.Enqueue("Your "+playerMon.refMon.name+" used "+playerMon.refMon.attkName+"! ");
                                    playerDmg=damage(playerMon, enemyMon, textList, pStatus, eStatus);
                                    enemyMon.currhp-=playerDmg;
                                    
                                }
                            }

                            textList.Enqueue("What will you do?");
                            attackButton.GetComponent<SpriteRenderer>().color=transCol;
                            swapButton.GetComponent<SpriteRenderer>().color=transCol;
                            runButton.GetComponent<SpriteRenderer>().color=transCol;
                            itemButton.GetComponent<SpriteRenderer>().color=transCol;

                            //for end of round stuff
                            prevEnemyMon=currEnemyMon;
                            prevPlayerMon=currCSMon;
                            pBurning = true;
                            eBurning=true;
                            pEffect=true;
                            eEffect=true;
                    
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
                    //if item
                    else if(buttonNum==3){
                        runButton.GetComponent<SpriteRenderer>().sprite=runOff;
                        attackButton.GetComponent<SpriteRenderer>().sprite=attackOff;
                        swapButton.GetComponent<SpriteRenderer>().sprite=swapOff;
                        itemButton.GetComponent<SpriteRenderer>().sprite=itemOn;
                        if(Input.GetKeyDown("space")){

                            if(PokeList.enemyList.Count>1){
                                textList.Enqueue("You can't catch this CS'Mon!");
                            }
                            else{
                                textList.Enqueue("You used a CS'Ball!");
                                textList.Enqueue("*Roll*Roll*Roll...");
                                attackButton.GetComponent<SpriteRenderer>().color=transCol;
                                swapButton.GetComponent<SpriteRenderer>().color=transCol;
                                runButton.GetComponent<SpriteRenderer>().color=transCol;
                                itemButton.GetComponent<SpriteRenderer>().color=transCol;
                            }
                            
                        }
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
                        //if not swapping out a dead csmon
                        if(playerMon.currhp>0){
                            textList.Enqueue("Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! ");
                            enemyDmg=damage(enemyMon, PokeList.ObtainedList[swapNum], textList, eStatus, pStatus);
                            PokeList.ObtainedList[swapNum].currhp-=enemyDmg;
                            
                        }
                        
                            
                      
                        currCSMon=swapNum;

                        textList.Enqueue("What will you do?");
                        pBurning = true;
                        eBurning=true;
                        pEffect=true;
                        eEffect=true;
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
            //trying to catch enemy
            else if(texter.text=="You ran away!"){
                if(Input.GetKeyDown("space")){
                    PokeList.enemyList= new List<PokeList.CSMon>();
                    SceneManager.LoadScene(texterScript.currLvlScene);
                }
            }

            else if(texter.text=="You used a CS'Ball!"){
                if(Input.GetKeyDown("space")){
                    enemy.GetComponent<SpriteRenderer>().color=transCol;
                    int chance=Random.Range(0,101);
                    //successfully catch them
                    if(chance>100.0*enemyMon.currhp/enemyMon.totalHp()){
                        textList.Enqueue("You caught "+enemyMon.refMon.name+"!");

                        //you win
                        
                        textList.Enqueue("You win this battle!");
                        PokeList.ObtainedList.Add(enemyMon);

                    }
                    //fail to catch them
                    else{
                        textList.Enqueue(enemyMon.refMon.name+" broke free!");
                        textList.Enqueue("Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! ");
                        enemyDmg=damage(enemyMon, playerMon, textList, eStatus, pStatus);
                        playerMon.currhp-=enemyDmg;  
                        pBurning=true;
                        eBurning=true;
                        pEffect=true;
                        eEffect=true;
                        textList.Enqueue("What will you do?");
                        
                    }
                }
            }
            else if(texter.text==enemyMon.refMon.name+" broke free!")
                enemy.GetComponent<SpriteRenderer>().color=showCol;

            //update health bars after normal attacks
            else if(texter.text=="Their "+enemyMon.refMon.name+" used "+enemyMon.refMon.attkName+"! "){
                if(Input.GetKeyDown("space"))
                    playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
                    
            }

            else if(texter.text=="Your "+playerMon.refMon.name+" used "+playerMon.refMon.attkName+"! "){
                if(Input.GetKeyDown("space"))
                    enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
                    
            }
            
            

            //when player swaps out
            else if(texter.text==PokeList.ObtainedList[swapNum].refMon.name+", I choose you!"){
                playerHPBar.rectTransform.sizeDelta= new Vector2(225*prevhp/playerMon.totalHp(), 25);
                currCSMon=swapNum;
                playerMon=PokeList.ObtainedList[currCSMon];
                GetComponent<SpriteRenderer>().sprite=playerMon.refMon.look;
               
                for(int i=1; i<=5; i++)
                    pStatus[i]=0;
            }
            //when enemy swaps out
            else if(texter.text=="The enemy sent out "+PokeList.enemyList[currEnemyMon].refMon.name+"! "){
                
                
                
                enemyMon=PokeList.enemyList[currEnemyMon];
                
                enemy.GetComponent<SpriteRenderer>().sprite=enemyMon.refMon.look;
                enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
                if(Input.GetKeyDown("space")){
                
                    for(int i=1; i<=5; i++)
                        eStatus[i]=0;
                    
                    textList.Enqueue("What will you do?");
                }

            }
            else if(texter.text=="Derrick cleared the enemy"+enemyMon.refMon.name+"'s line!"){
                enemyHPBar.rectTransform.sizeDelta= new Vector2(225*enemyMon.currhp/enemyMon.totalHp(), 25);
            }
            else if(texter.text=="Derrick cleared your "+playerMon.refMon.name+"'s line!"){
                playerHPBar.rectTransform.sizeDelta= new Vector2(225*playerMon.currhp/playerMon.totalHp(), 25);
            }
            //leaving the room
            else if(texter.text=="You lose this battle!"){
                
                if(Input.GetKeyDown("space")){
                    for(int i=0; i<swapButtons.Length; i++){
                        PokeList.ObtainedList[i].currhp=PokeList.ObtainedList[i].totalHp();
                    }
                    texterScript.playerPos=new Vector2(11, 14);
                    texterScript.currLvlScene="Level1Room";
                    
                    PokeList.enemyList= new List<PokeList.CSMon>();
                    SceneManager.LoadScene(texterScript.currLvlScene);
                }
            }
            else if(texter.text=="You win this battle!"){
                if(Input.GetKeyDown("space")){
                    PokeList.enemyList= new List<PokeList.CSMon>();
                    SceneManager.LoadScene(texterScript.currLvlScene);
                }
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
            if(a.refMon==PokeList.Krish){
                if(dice<d.refMon.acc){
                    res=d.refMon.attk*a.lvl();
                    t.Enqueue("It landed!");
                    if((a.refMon.type=="Fire" && d.refMon.type=="Grass") || (a.refMon.type=="Grass" && d.refMon.type=="Water") || (a.refMon.type=="Water" && d.refMon.type=="Fire")){
                        res*=3;
                        res/=2;
                        t.Enqueue("It was super effective!");
                    }
                    else if((a.refMon.type=="Fire" && d.refMon.type=="Water") || (a.refMon.type=="Grass" && d.refMon.type=="Fire") || (a.refMon.type=="Water" && d.refMon.type=="Grass")){
                        res/=2;
                        t.Enqueue("It wasn't very effective...");
                    }
                    dice=Random.Range(0, 101);
                    if(dice<d.refMon.critChance){
                        res*=3;
                        res/=2;
                        t.Enqueue("Critical Hit!");
                    }
                        
                }
                else{
                    t.Enqueue("It missed!");
                    return 0;
                }


            }
            else{
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
                        t.Enqueue(a.refMon.name+" was milk'd on, so "+a.refMon.name+" did less damage!");
                        res/=2;
                    }
                    res*=(s[4]+1);
                //checks to see damage change due to specific CSMon
                
                    if(a.refMon==PokeList.Andrew && s[1]<4){
                        t.Enqueue("Andrew is speeding up!");
                        s[1]++;
                    }
                    else if(a.refMon==PokeList.Byeongguk){
                        t.Enqueue("Byeongguk's whole team is speeding up!");
                        s[0]++;
                    }
                    else if(a.refMon==PokeList.Steven)
                        res*=(1+ (a.currhp)/a.totalHp());
                    else if(a.refMon==PokeList.Catherine && s[4]<4){
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

        
                
                
            
            
            

        }
        return res;
    }

    
}

