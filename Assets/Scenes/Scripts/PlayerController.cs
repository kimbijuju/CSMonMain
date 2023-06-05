using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask grassLayer;


    private bool isMoving;
    private Vector2 input;
    
    //checking if spawn time
    public static bool spawnNow;
    private void Start(){
    //Bijou work
        GetComponent<SpriteRenderer>().sprite=texterScript.tonySprite;
        transform.position=texterScript.playerPos;
        //
    }
    private void Update()
    {
        //Bijou work
        if(Input.GetKeyDown("space"))
            SceneManager.LoadScene("OptionsScene");
        texterScript.playerPos=transform.position;

        //Tony's work

        float speed = 7f;
        
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            input.y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

           

            if (input != Vector2.zero)
            {

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                
                if (IsWalkable(targetPos)) {
                    //StartCoroutine(Move(targetPos));
                    transform.position = targetPos;
                    CheckForEncounters();
                }
            }
        }
        

        
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();

    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, -0.2f, solidObjectsLayer) != null)
        {
            return false;
        }

        return true;
    }
    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            if (Random.Range(1, 5001) <= 10)
            {
                spawnNow=true;
                
            }
        }
    }
}






