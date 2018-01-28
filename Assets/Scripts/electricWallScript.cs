using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricWallScript : MonoBehaviour {

    public float moveSpeed;
    public float delay;
    private bool isMoving = false;

    private Rigidbody2D rb2d;
    
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void Update () {
        if (delay < 0) return;

        delay -= Time.deltaTime;

        if (delay > 0) return;

        rb2d.AddForce(new Vector2(moveSpeed, 0));
    }
}
