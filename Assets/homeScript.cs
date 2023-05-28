using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homeScript : MonoBehaviour
{
    public GameObject battleButton;
    public GameObject storyButton;

    public Sprite battleOn;
    public Sprite battleOff;
    public Sprite storyOn;
    public Sprite storyOff;

    public int buttonNum;
    // Start is called before the first frame update
    void Start()
    {
        buttonNum=-1;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)){
            buttonNum*=-1;
        }
        
        if(buttonNum==-1){
            battleButton.GetComponent<SpriteRenderer>().sprite=battleOff;
            storyButton.GetComponent<SpriteRenderer>().sprite=storyOn;
            if(Input.GetKeyDown("space"))
                SceneManager.LoadScene("Start Scene");
        }
        if(buttonNum==1){
            battleButton.GetComponent<SpriteRenderer>().sprite=battleOn;
            storyButton.GetComponent<SpriteRenderer>().sprite=storyOff;
            if(Input.GetKeyDown("space")){
                SceneManager.LoadScene("pickScreen");
            }
        }
        
    }
}
