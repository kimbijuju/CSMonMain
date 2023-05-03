using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blurScript : MonoBehaviour
{
    public GameObject CSDex;
    public SpriteRenderer rend;
    public Vector3 ogPos;
    public Vector3 newPos;
    public Color newCol;
    public int changing;
    public Sprite prevSprite;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rend=GetComponent<SpriteRenderer>();
        ogPos= CSDex.transform.position;
        newPos=ogPos;
        newCol=new Color(1,1,1,0f);
        changing=0;

        

 
    }

    // Update is called once per frame
    
    void Update()
    {
        
        prevSprite=PokeList.ObtainedList[PokeScript.prevNum].refMon.look;
        rend.sprite=prevSprite;
        if(newCol.a>=0){
            newCol.a-=0.05f;
            rend.color=newCol;
        }
        gameObject.transform.position= newPos;
        if(changing==1)
            newPos.x-=0.3f;
        if(changing==2)
            newPos.x+=0.3f;
            

        if(Input.GetKeyDown(KeyCode.D)){
            
            newPos=ogPos;
            newCol.a=1f;
            changing=1;
            
            
        }
        if(Input.GetKeyDown(KeyCode.A)){
            newPos=ogPos;
            newCol.a=1f;
            changing=2;
            
            
        }
        
    }
    
}
