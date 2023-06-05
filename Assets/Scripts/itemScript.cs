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
    public Sprite exitOn;
    public Sprite exitOff;
    public GameObject exitButton;
    public int buttonNum;
    public GameObject CSMonButton;
    public int CSMonIndex;
    // Start is called before the first frame update
    void Start()
    {
        ItemIndex = 0;
        selected = false;
        buttonNum = -1;
        CSMonIndex = 0;
    }


    // Update is called once per frame\
    void Update()
    {
        /*
        if (selected == false)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                buttonNum *= 1;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                ItemIndex++;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                ItemIndex--;
            }
            else if (ItemIndex >= 5)
            {
                ItemIndex = 0;
            }
            else if (ItemIndex < 0)
            {
                ItemIndex = 4;
            }
            numOfPotion.text = NumItems[ItemIndex];
            else if (ItemIndex == 0)
            {
                GetComponent<SpriteRenderer>().sprite = 50heal;
            }
            else if (buttonNum == -1)
            {
                if (Input.GetKeyDown("space"))
                {
                    SceneManager.LoadScene(texterScript.currLvlScene);
                }
            }
            else if (buttonNum == 1)
            {
                if (Input.GetKeyDown("space"))
                {
                    seleected = true;
                }
            }
        }
        */
        else if (selected == true) 
        {
            CSMonButton.GetComponent<SpriteRenderer>().sprite = PokeList.ObtainedList[CSMonIndex].refMon.look;
            else if (Input.GetKeyDown(KeyCode.D))
            {
                CSMonIndex++;
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                CSMonIndex--;
            }
            else if (CSMonIndex >= PokeList.ObtainedList.length)
            {
                CSMonIndex = 0;
            }
            else if (CSMonIndex < PokeList.ObtainedList.length)
            {
                CSMonIndex = PokeList.ObtainedList.length - 1;
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                buttonNum *= 1;
            }
            else if (buttonNum == -1)
            {
                if (Input.GetKeyDown("space"))
                {
                    selected = false;
                }
            }
        /*
            else if (buttonNum == 1)
            {
                if (Input.GetKeyDown("space")
                {
                    if (ItemIndex == 0)
                    {
                        if (PokeList.ObtainedList[CSMonIndex].currhp > 0)
                        {
                            PokeList.ObtainedList[CSMonIndex].currhp = PokeList.ObtainedList[CSMonIndex].currhp + PokeList.ObtainedList[CSMonIndex].totalHp() / 2);
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
                            PokeList.ObtainedList[CSMonIndex].currhp = PokeList.ObtainedList[CSMonIndex].currhp + PokeList.ObtainedList[CSMonIndex].totalHp() *3 / 4);
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
        */
        } 
    }
}

