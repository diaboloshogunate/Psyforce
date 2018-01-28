using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatewayScript : MonoBehaviour {
    public GameObject[] m_buttons;
    public bool isDown = true;
    public float time = 0.1f;
    public float distance = 5;
    private Vector2 moveFrom;
    private Vector2 moveTo;
    private bool moving = false;
    private float smooth = 0f;
    protected Rigidbody2D rb2d;
    
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
    public void buttonPressed()
    {
        if (moving) return;
        moving = true;
        int direction = isDown ? 1 : -1;
        smooth = 0f;
        moveFrom = rb2d.position;
        moveTo = moveFrom + new Vector2(0, direction * distance);
}
    
    void Update () {
        if (!moving) return;
        if (rb2d.position == moveTo)
        {
            moving = !moving;
            isDown = !isDown;
        }
        smooth += Time.deltaTime * time;
        transform.position = Vector2.Lerp(moveFrom, moveTo, smooth);
    }
}
