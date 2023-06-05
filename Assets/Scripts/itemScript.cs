using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class itemScript : MonoBehaviour
{
    public int ItemIndex;
    public int PrevIndex;
    public Sprite fiveheal;
    public Sprite sevenheal;
    public Sprite oneheal;
    public Sprite singleRevive;
    public Sprite teamRevive;
    public Text numOfPotion;
    public bool selected;

    public Text desc;

    public Sprite exitOn;
    public Sprite exitOff;
    public GameObject exitButton;
    
    public GameObject useButton;
    public Sprite useOn;
    public Sprite useOff;
    
    public int buttonNum;


    public GameObject CSMonButton;
    public int CSMonIndex;

    public string itemsText;

    public Color transCol;
    public Color showCol;
    public Color redCol;
    public Color greenCol;

    public Image hpBar;
    public Image fullBar;
    public Vector2 hpSet;
    // Start is called before the first frame update
    void Start()
    {
        hpSet= new Vector2(0,51);

        ItemIndex = 0;
        selected = false;
        buttonNum = -1;
        CSMonIndex = 0;

        transCol=new Color(1,1,1,0f);
        showCol=new Color(1,1,1,1f);

        greenCol=new Color(0,1,0,1f);

        redCol=new Color(1,0,0,1f);
    }


    // Update is called once per frame\
    void Update()
    {
        
        if (selected == false)
        {
            CSMonButton.GetComponent<SpriteRenderer>().color=transCol;
            fullBar.GetComponent<Image>().color=transCol;
            hpBar.GetComponent<Image>().color=transCol;
            GetComponent<SpriteRenderer>().color=showCol;

            numOfPotion.text=""+texterScript.NumItems[ItemIndex];

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                buttonNum *= -1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ItemIndex++;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ItemIndex--;
            }
            if (ItemIndex >4)
            {
                ItemIndex = 0;
            }
            else if (ItemIndex < 0)
            {
                ItemIndex = 4;
            }
            
            
            if (ItemIndex == 0)
            {
                GetComponent<SpriteRenderer>().sprite = fiveheal;
                desc.text="Heals 50% of one CS'Mon's total hp.";

            }
            else if (ItemIndex == 1)
            {
                GetComponent<SpriteRenderer>().sprite = sevenheal;
                desc.text="Heals 75% of one CS'Mon's total hp.";
            }
            else if (ItemIndex == 2)
            {
                GetComponent<SpriteRenderer>().sprite = oneheal;
                desc.text="Heals 100% of one CS'Mon's total hp.";
            }
            else if (ItemIndex == 3)
            {
                GetComponent<SpriteRenderer>().sprite = singleRevive;
                desc.text="Revives one CS'Mon to full health.";
            }
            else if (ItemIndex == 4)
            {
                GetComponent<SpriteRenderer>().sprite = teamRevive;
                desc.text="Revives your whole team to full health.";
            }
            

            if (buttonNum == -1)
            {
                exitButton.GetComponent<SpriteRenderer>().sprite=exitOn;
                useButton.GetComponent<SpriteRenderer>().sprite=useOff;
                if (Input.GetKeyDown("space"))
                {
                    SceneManager.LoadScene(texterScript.currLvlScene);
                }
            }
            else if (buttonNum == 1)
            {
                exitButton.GetComponent<SpriteRenderer>().sprite=exitOff;
                useButton.GetComponent<SpriteRenderer>().sprite=useOn;
                if (Input.GetKeyDown("space"))
                {
                    if(texterScript.NumItems[ItemIndex]>0){
                        if(ItemIndex==4){
                            foreach(PokeList.CSMon i in PokeList.ObtainedList){
                                i.currhp=i.totalHp();

                            }
                            texterScript.NumItems[ItemIndex]--;
                        }
                        else
                            selected = true;
                    }
                }
            }
        }
        
        else if (selected == true) 
        {
            hpSet.x=274*PokeList.ObtainedList[CSMonIndex].currhp/PokeList.ObtainedList[CSMonIndex].totalHp();
            hpBar.rectTransform.sizeDelta=hpSet;
            numOfPotion.text="";
            CSMonButton.GetComponent<SpriteRenderer>().color=showCol;
            fullBar.GetComponent<Image>().color=redCol;
            hpBar.GetComponent<Image>().color=greenCol;
            GetComponent<SpriteRenderer>().color=transCol;

            CSMonButton.GetComponent<SpriteRenderer>().sprite = PokeList.ObtainedList[CSMonIndex].refMon.look;
            if (Input.GetKeyDown(KeyCode.D))
            {
                CSMonIndex++;
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                CSMonIndex--;
            }
            if (CSMonIndex >= PokeList.ObtainedList.Count)
            {
                CSMonIndex = 0;
            }
            else if (CSMonIndex < 0)
            {
                CSMonIndex = PokeList.ObtainedList.Count - 1;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                buttonNum *= -1;
            }
            if (buttonNum == -1)
            {
                exitButton.GetComponent<SpriteRenderer>().sprite=exitOn;
                useButton.GetComponent<SpriteRenderer>().sprite=useOff;

                if (Input.GetKeyDown("space"))
                {
                    selected = false;
                }
            }
            
            else if (buttonNum == 1)
            {
                exitButton.GetComponent<SpriteRenderer>().sprite=exitOff;
                useButton.GetComponent<SpriteRenderer>().sprite=useOn;

                if (Input.GetKeyDown("space"))
                {
                    if (ItemIndex == 0)
                    {
                        if (PokeList.ObtainedList[CSMonIndex].currhp > 0)
                        {
                            PokeList.ObtainedList[CSMonIndex].currhp = PokeList.ObtainedList[CSMonIndex].currhp + (PokeList.ObtainedList[CSMonIndex].totalHp() / 2);
                            if (PokeList.ObtainedList[CSMonIndex].currhp > PokeList.ObtainedList[CSMonIndex].totalHp())
                            {
                                PokeList.ObtainedList[CSMonIndex].currhp = PokeList.ObtainedList[CSMonIndex].totalHp();
                            }
                            texterScript.NumItems[ItemIndex]--;
                            selected = false;
                        }
                    }
                    else if (ItemIndex == 1)
                    {
                        if (PokeList.ObtainedList[CSMonIndex].currhp > 0)
                        {
                            PokeList.ObtainedList[CSMonIndex].currhp = PokeList.ObtainedList[CSMonIndex].currhp + (PokeList.ObtainedList[CSMonIndex].totalHp() *3 / 4);
                            if (PokeList.ObtainedList[CSMonIndex].currhp > PokeList.ObtainedList[CSMonIndex].totalHp())
                            {
                                PokeList.ObtainedList[CSMonIndex].currhp = PokeList.ObtainedList[CSMonIndex].totalHp();
                            }
                            texterScript.NumItems[ItemIndex]--;
                            selected = false;
                        }
                    }
                    else if (ItemIndex == 2)
                    {
                        if (PokeList.ObtainedList[CSMonIndex].currhp > 0)
                        {
                            PokeList.ObtainedList[CSMonIndex].currhp = PokeList.ObtainedList[CSMonIndex].totalHp();
                            texterScript.NumItems[ItemIndex]--;
                            selected = false;
                        }
                    }
                
                    else if (ItemIndex == 3)
                    {
                        PokeList.ObtainedList[CSMonIndex].currhp = PokeList.ObtainedList[CSMonIndex].totalHp();
                        texterScript.NumItems[ItemIndex]--;
                        selected = false;
                    }
                }
            }
        
        } 
    }
}

