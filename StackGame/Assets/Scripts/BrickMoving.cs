using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMoving : MonoBehaviour {

    //private Rigidbody2D rb;
    private float x;
    void Start () {
        sizeToScreen();
        x = transform.position.x;
    }
	
	void Update () {
        transform.position = new Vector3(x,transform.position.y, 0);
        transform.rotation = Quaternion.identity;
	}
    void OnCollisionEnter2D(Collision2D Collision)
    {
       // Instantiate(gameObject, new Vector3(x, transform.position.y, 0), Quaternion.identity);
        //Destroy(gameObject);
    }
    void sizeToScreen() //fit scale of brick to size of screen
    {
        float diff;
        SpawningBricks SBscript = GameObject.Find("GameController").GetComponent<SpawningBricks>();
        diff = 2 * SBscript.rightEdge;
        transform.localScale = new Vector3(diff / 6, diff / 6, 0);
    }
}
