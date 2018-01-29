using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatewayScript : MonoBehaviour
{
    public bool moving = false;
    public bool isDown = true;
    public float speed = 0.5f;
    public float distance = 5;
    protected Rigidbody2D rb2d;
    public Vector2 moveFrom;
    public Vector2 moveTo;
    private float start;
    public float smooth = 0f;
    
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        positions();
    }

    public void positions()
    {
        int direction = isDown ? 1 : -1;
        moveFrom = rb2d.transform.position;
        moveTo = moveFrom + new Vector2(0, direction * distance);
    }
	
    public void buttonPressed()
    {
        if (moving) return;
        positions();
        moving = true;
        start = Time.time;
    }
    
    void Update () {
        if (!moving) return;
        
        if (Mathf.Abs(rb2d.transform.position.y - moveTo.y) < 0.01)
        {
            moving = !moving;
            isDown = !isDown;
        }

        smooth = (Time.time - start) * speed / Mathf.Abs(distance);
        rb2d.transform.position = Vector2.Lerp(moveFrom, moveTo, smooth);
    }
}
