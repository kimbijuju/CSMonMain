using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;

    private bool isMoving;
    private Vector2 input;

   
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
            SceneManager.LoadScene("CSDex Scene");
        texterScript.playerPos=transform.position;

        //Tony's work
        
        if (!isMoving)
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");

           

            if (input != Vector2.zero)
            {

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                
                if (IsWalkable(targetPos)) {
                    StartCoroutine(Move(targetPos));
                 
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
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, -0.2f, solidObjectsLayer) != null)
        {
            return false;
        }

        return true;
    }
}






