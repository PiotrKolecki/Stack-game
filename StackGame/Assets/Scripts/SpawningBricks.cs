using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpawningBricks : MonoBehaviour {

    public GameObject [] bricks;
    public GameObject bottom;
    private int i,j;
    public Text LR , size;
    [HideInInspector]
        public float leftEdge, rightEdge, bottomY, topY, sizeofBrick;
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
        GameObject resp = GameObject.FindWithTag("MovingBricks");
        if (resp == null)
        {
            j = Random.Range(0, 3);
            i = Random.Range(0, 6);
            Instantiate(bricks[j], new Vector3(leftEdge +sizeofBrick * (0.5f + i), topY + sizeofBrick, 0), Quaternion.identity);
        }
	}
}
