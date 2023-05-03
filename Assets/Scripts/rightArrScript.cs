
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightArrScript : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.D))
            imageRend.sprite=onSp;
        else if(Input.GetKeyUp(KeyCode.D))
            imageRend.sprite=offSp;
    }
    
}
