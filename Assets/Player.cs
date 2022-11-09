using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    public Vector3Int tilePos;
    private Sprite curTile;
    private float timeToMove = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print("hello there");
        //transform.Translate(0, 1, 0);
        //transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0f);
        
        if (Input.GetKey(KeyCode.W) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));

        if (Input.GetKey(KeyCode.A) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));

        if (Input.GetKey(KeyCode.S) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));

        if (Input.GetKey(KeyCode.D) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));

    }

    private bool MoveTest(Vector3 start, Vector3 end)
    {
        //Check For wall collision before moving player
        //bool hit = Physics2D.Linecast(start, end);

        if (Physics2D.Linecast(start, end) == true)
        {
            return true;
        }
        else
        {
            return false;   
        }
    }

    private void UpdateTile(Vector3 playerPos)
    {
        tilePos = Vector3Int.FloorToInt(playerPos);
        curTile = Tilemap.GetSprite(tilePos);
    }


    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        

        origPos = transform.position;
        targetPos = origPos + (direction * 8);


            if (MoveTest(origPos,targetPos) == false)
        {
            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPos;
        }

        /*
        if targetPos == //Colortile
        {
            if color is red
               color = green

        }
        */

        

        isMoving = false;
    }
}
