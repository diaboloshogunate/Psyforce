using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electricWallScript : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(moveSpeed, 0));
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("kill");
            Debug.Log("Kill message sent");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
