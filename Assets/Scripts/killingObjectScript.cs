using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killingObjectScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("kill");
            Debug.Log("Kill message sent");
        }
    }
}
