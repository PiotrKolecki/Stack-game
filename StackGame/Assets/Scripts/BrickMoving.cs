using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMoving : MonoBehaviour {

    private Rigidbody2D rb;
	void Start () {
       // rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0, -5);
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionEnter2D(Collision2D Collision)
    {
        //rb.isKinematic = true;
    }
}
