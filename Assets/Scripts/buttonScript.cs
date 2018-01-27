using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour {

    public Sprite downSprite;
    public Sprite upSprite;
    public GameObject targetObject;
    public bool moveTargetUp;

    private bool isDown;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(isDown)
        {
            spriteRenderer.sprite = downSprite;
        }
        else
        {
            spriteRenderer.sprite = upSprite;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Button " + gameObject.name + " Pushed");
            int direction = -1;
            if(!moveTargetUp) { direction = 1; }
            targetObject.SendMessage("buttonPressed", direction);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           isDown = true;
        }
    }
}
