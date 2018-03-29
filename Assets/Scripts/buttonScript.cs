using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour {

    public Sprite downSprite;
    public Sprite upSprite;
    public GameObject[] m_targetObject;

    private bool isDown;
    private SpriteRenderer spriteRenderer;
    AudioSource audio;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isDown = true;
            audio.Play();

            foreach (GameObject o in m_targetObject)
            {
                o.SendMessage("buttonPressed");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isDown = false;
            audio.Play();
        }
    }
}
