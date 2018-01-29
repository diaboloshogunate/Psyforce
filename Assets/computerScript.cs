using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerScript : MonoBehaviour {

    public GameObject targetplayer;
    public gameController gameManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == targetplayer)
        {
            gameManager.SendMessage("WinState");
        }
    }
}
