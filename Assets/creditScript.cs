using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditScript : MonoBehaviour
{
    public Vector2 currPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currPos.y+=0.01f;
        transform.position=currPos;
    }
}
