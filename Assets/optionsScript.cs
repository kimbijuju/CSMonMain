using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionsScript : MonoBehaviour
{
    public GameObject returnButton;
    public GameObject itemButton;
    public int optionsNum;

    public Sprite itemOn;
    public Sprite itemOff;
    public Sprite csOn;
    public Sprite csOff;
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
                optionsNum=2;
        }

        else if(Input.GetKeyDown(KeyCode.D)){
            optionsNum++;
            if(optionsNum>2)
                optionsNum=0;
        }
        
        //go back home 
        if(optionsNum==0){
            returnButton.GetComponent<SpriteRenderer>().sprite=returnOn;
            GetComponent<SpriteRenderer>().sprite=csOff;
            itemButton.GetComponent<SpriteRenderer>().sprite=itemOff;
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene(texterScript.currLvlScene);
            }
        }
        // to csdex scene
        else if(optionsNum==1){
            returnButton.GetComponent<SpriteRenderer>().sprite=returnOff;
            GetComponent<SpriteRenderer>().sprite=csOn;
            itemButton.GetComponent<SpriteRenderer>().sprite=itemOff;
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene("CSDex Scene");
            }
        }
        else if(optionsNum==2){
            returnButton.GetComponent<SpriteRenderer>().sprite=returnOff;
            GetComponent<SpriteRenderer>().sprite=csOff;
            itemButton.GetComponent<SpriteRenderer>().sprite=itemOn;
            if(Input.GetKeyDown("space")){

            }
        }



    }
}
