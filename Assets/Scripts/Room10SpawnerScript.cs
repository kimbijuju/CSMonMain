using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room10SpawnerScript : MonoBehaviour
{
    public GameObject player;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer=0;
    }

    // Update is called once per frame
    void Update()
    {

        if(player.transform.position.x > 208 && player.transform.position.y < -85) 
        {
            texterScript.playerPos.x=-6f;
            texterScript.playerPos.y=-1f;
            SceneManager.LoadScene("DemoRoom10");
        }
            

    }
}
