using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatewayScript : MonoBehaviour {
    public GameObject[] m_buttons;
    public bool isDown = true;
    public float time = 0.1f;
    public float distance = 5;
    private Vector3 moveFrom;
    private Vector3 moveTo;
    private bool moving = false;
    private float smooth = 0f;

    private Rigidbody2D rigidBody;
    
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
    public void buttonPressed()
    {
        if (moving) return;
        moving = true;
        int direction = isDown ? 1 : -1;
        smooth = 0f;
        moveFrom = transform.position;
        moveTo = moveFrom + new Vector3(0, direction * distance, 0);
}
    
    void Update () {
        if (!moving) return;
        if (transform.position == moveTo)
        {
            moving = !moving;
            isDown = !isDown;
        }
        smooth += Time.deltaTime * time;
        transform.position = Vector3.Lerp(moveFrom, moveTo, smooth);
    }
}
