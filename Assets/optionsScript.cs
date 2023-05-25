using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsScript : MonoBehaviour
{
    public GameObject returnButton;
    public GameObject itemButton;
    public GameObject teamButton;
    public int optionsNum;
    public static List<PokeList.CSMon> listOfMon; 
    public static bool team;

    public Sprite itemOn;
    public Sprite itemOff;
    public Sprite csOn;
    public Sprite csOff;
    public Sprite teamOn;
    public Sprite teamOff;
    public Sprite returnOn;
    public Sprite returnOff;
    // Start is called before the first frame update
    void Start()
    {
        optionsNum=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            optionsNum--;
            if(optionsNum<0)
                optionsNum=3;
        }

        else if(Input.GetKeyDown(KeyCode.D)){
            optionsNum++;
            if(optionsNum>3)
                optionsNum=0;
        }
        
        //go back home 
        if(optionsNum==0){
            returnButton.GetComponent<SpriteRenderer>().sprite=returnOn;
            GetComponent<SpriteRenderer>().sprite=csOff;
            itemButton.GetComponent<SpriteRenderer>().sprite=itemOff;
            teamButton.GetComponent<SpriteRenderer>().sprite=teamOff;
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene(texterScript.currLvlScene);
            }
        }
        // to csdex scene
        else if(optionsNum==1){
            returnButton.GetComponent<SpriteRenderer>().sprite=returnOff;
            GetComponent<SpriteRenderer>().sprite=csOn;
            itemButton.GetComponent<SpriteRenderer>().sprite=itemOff;
            teamButton.GetComponent<SpriteRenderer>().sprite=teamOff;
            if(Input.GetKeyDown("space")){
                listOfMon=PokeList.allList;
                team=false;
                SceneManager.LoadScene("CSDex Scene");
            }
        }
        //to team scene
        else if(optionsNum==2){
            returnButton.GetComponent<SpriteRenderer>().sprite=returnOff;
            GetComponent<SpriteRenderer>().sprite=csOff;
            itemButton.GetComponent<SpriteRenderer>().sprite=itemOff;
            teamButton.GetComponent<SpriteRenderer>().sprite=teamOn;
            if(Input.GetKeyDown("space")){
                listOfMon=PokeList.ObtainedList;
                team=true;
                SceneManager.LoadScene("CSDex Scene");
            }
        }

        //to item scene
        else if(optionsNum==3){
            returnButton.GetComponent<SpriteRenderer>().sprite=returnOff;
            GetComponent<SpriteRenderer>().sprite=csOff;
            itemButton.GetComponent<SpriteRenderer>().sprite=itemOn;
            teamButton.GetComponent<SpriteRenderer>().sprite=teamOff;
            if(Input.GetKeyDown("space")){

            }
        }



    }
}
