using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawningBricks : MonoBehaviour {

    public GameObject [] bricks;
    private float bottomY, topY;
    public GameObject bottom;
    public float delay = 1f;
    private float newResp = 0f;
    private int i;
    public Text LR , size;
    private float sizeofBrick;
    [HideInInspector]
    public float leftEdge, rightEdge;
    void Awake()
    {
        leftEdge = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        rightEdge = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        bottomY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        topY = Camera.main.ViewportToWorldPoint(new Vector2(0, 1)).y;
    }
    void Start () {

        Instantiate(bottom, new Vector2(0, bottomY), Quaternion.identity);
        LR.text = "Left edge: " + leftEdge + " Right edge: " + rightEdge;
        sizeofBrick = 2 * rightEdge / 6;
        size.text = "" + sizeofBrick;
    }

    void Update () {
        if(Time.time > newResp)
        {
            newResp = Time.time + delay;
            i = Random.Range(0, 6);
            if (i == 0)
                Instantiate(bricks[i], new Vector3(leftEdge, topY + sizeofBrick, 0), Quaternion.identity);
            else if(i==5)
                Instantiate(bricks[i], new Vector3(rightEdge, topY + sizeofBrick, 0), Quaternion.identity);
            else
                Instantiate(bricks[i], new Vector3(leftEdge +sizeofBrick * (0.5f + i), topY + sizeofBrick, 0), Quaternion.identity);
        }
	}
}
