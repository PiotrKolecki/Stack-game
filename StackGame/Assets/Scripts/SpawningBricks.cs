using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBricks : MonoBehaviour {

    public GameObject [] bricks;
    private float bottomY;
    public GameObject bottom;
    public float delay = 1f;
    private float newResp = 0f;
    private float leftEdge, rightEdge;
    private int i;
    void Start () {
        bottomY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        Instantiate(bottom, new Vector2(0, bottomY), Quaternion.identity);
    }

    void Update () {
        if(Time.time > newResp)
        {
            newResp = Time.time + delay;
            i = Random.Range(0, 6);
            Instantiate(bricks[i], bricks[i].transform.position, Quaternion.identity);
        }
	}
}
