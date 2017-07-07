using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickMoving : MonoBehaviour {

    SwipeDetection swipe;
    GameController GCscript;
    SpawningBricks SBscript;
    private float x, width;
    public GameObject brick, rayPositionL, rayPositionR;
    void Start () {
        sizeToScreen();
        x = transform.position.x;
        swipe = GameObject.Find("GameController").GetComponent<SwipeDetection>();
        GCscript = GameObject.Find("GameController").GetComponent<GameController>();
        SBscript = GameObject.Find("GameController").GetComponent<SpawningBricks>();
    }

    void FixedUpdate() {
        transform.position = new Vector3(x, transform.position.y, 0);
        if (swipe.forTouch() < 0)       //swipe.forMouse() when PC swipe.forTouch() when Android
        {
            RaycastHit2D hit = Physics2D.Raycast(rayPositionL.transform.position,Vector2.left, SBscript.sizeofBrick);
            if (x != SBscript.leftEdge + 0.5f * SBscript.sizeofBrick && !hit.collider) //Swipe left
                x -= width/6;
        }
        else if(swipe.forTouch()>0)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayPositionR.transform.position, Vector2.right, SBscript.sizeofBrick);
            if (x != SBscript.rightEdge - 0.5f * SBscript.sizeofBrick && !hit.collider)  // Swipe right
                x += width/6;
        }
	}
    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (name == "DownBrick(Clone)")
        {
            float tempY = Collision.transform.tag == "Bottom" ? Collision.transform.position.y + 0.5f * SBscript.sizeofBrick 
                        : Collision.transform.position.y + SBscript.sizeofBrick;
            Instantiate(brick, new Vector3(x, tempY, 0), Quaternion.identity);
            GCscript.inColumn(x);
        }
        else if (name == "LeftBrick(Clone)")
        {
            int columnNumber = (int)((x - SBscript.leftEdge) / SBscript.sizeofBrick - 0.5f) - 1;
            float tempY, tempX;
            if (columnNumber < 0)
            {
                columnNumber = 5;
                tempX = SBscript.rightEdge - 0.5f * SBscript.sizeofBrick;
                tempY = SBscript.bottomY + SBscript.sizeofBrick * (GCscript.columns[columnNumber] + 0.5f);
            }
            else
            {
                tempX = x - SBscript.sizeofBrick;
                tempY = SBscript.bottomY + SBscript.sizeofBrick * (GCscript.columns[columnNumber] + 0.5f);
            }
            Instantiate(brick, new Vector3(tempX, tempY, 0), Quaternion.identity);
            GCscript.inColumn(tempX);
        }
        else if (name == "RightBrick(Clone)")
        {
            int columnNumber = (int)((x - SBscript.leftEdge) / SBscript.sizeofBrick - 0.5f) + 1;
            float tempY, tempX;
            if (columnNumber > 5)
            {
                columnNumber = 0;
                tempX = SBscript.leftEdge + 0.5f * SBscript.sizeofBrick;
                tempY = SBscript.bottomY + SBscript.sizeofBrick * (GCscript.columns[columnNumber] + 0.5f);
            }
            else
            {
                tempX = x + SBscript.sizeofBrick;
                tempY = SBscript.bottomY + SBscript.sizeofBrick * (GCscript.columns[columnNumber] + 0.5f);
            }
            Instantiate(brick, new Vector3(tempX, tempY, 0), Quaternion.identity);
            GCscript.inColumn(tempX);
        }
        Destroy(gameObject);
    }
    void sizeToScreen() //fit scale of brick to size of screen
    {
        SpawningBricks SBscript = GameObject.Find("GameController").GetComponent<SpawningBricks>();
        width = 2 * SBscript.rightEdge;
        transform.localScale = new Vector3(SBscript.sizeofBrick, SBscript.sizeofBrick, 0);
    }
}
