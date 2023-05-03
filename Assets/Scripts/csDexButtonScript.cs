using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class csDexButtonScript : MonoBehaviour
{
    
    public Vector2 buttonSize;
    public PokeList.CSMon tempMon;
    public GameObject exitButton;
    public SpriteRenderer rend;
    public Sprite swapOn;
    public Sprite swapOff;
    public Sprite exitOn;
    public Sprite exitOff;
    public int buttonNum;
    public int firstNum;
    public int secondNum;
    public bool swapping;
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<SpriteRenderer>();
        buttonNum=0;
        firstNum=0;
        secondNum=0;
        buttonSize=new Vector2(3.3f, 3.3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().localScale=buttonSize;
        //setting buttonNum
        if(!swapping){
            if(Input.GetKeyDown(KeyCode.W)){
                buttonNum--;
            }

            if(Input.GetKeyDown(KeyCode.S)){
                buttonNum++;
            }
            if(buttonNum>1)
                buttonNum=0;
            else if(buttonNum<0)
                buttonNum=1;

            if(buttonNum==1){
                rend.sprite=swapOn;
                exitButton.GetComponent<SpriteRenderer>().sprite=exitOff;
                if(Input.GetKeyDown("space")){
                    firstNum=PokeScript.pokeNum;
                    rend.sprite=PokeList.ObtainedList[firstNum].refMon.look;
                    swapping=true;
                    buttonSize.x=0.5f;
                    buttonSize.y=0.5f;
                }
            }

            else if(buttonNum==0){
                rend.sprite=swapOff;
                exitButton.GetComponent<SpriteRenderer>().sprite=exitOn;
                if(Input.GetKeyDown("space")){
                    SceneManager.LoadScene(texterScript.currLvlScene);
                }
            }
        }
        else{
            if(Input.GetKeyDown("space")){
                secondNum=PokeScript.pokeNum;
                tempMon=PokeList.ObtainedList[secondNum];
                PokeList.ObtainedList[secondNum]=PokeList.ObtainedList[firstNum];
                PokeList.ObtainedList[firstNum]=tempMon;
                swapping=false;
                buttonSize.x=3.3f;
                buttonSize.y=3.3f;

            }
        }
    }
}
