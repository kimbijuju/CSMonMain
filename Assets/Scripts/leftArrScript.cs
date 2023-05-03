using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftArrScript : MonoBehaviour
{
    
    public Sprite onSp;
    public Sprite offSp;
    SpriteRenderer imageRend;

    // Start is called before the first frame update
    void Start()
    {
        imageRend=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            imageRend.sprite=onSp;
        else if(Input.GetKeyUp(KeyCode.A))
            imageRend.sprite=offSp;
    }
    
}
