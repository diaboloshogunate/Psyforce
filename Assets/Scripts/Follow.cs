using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public float targetX;
    public float smooth = 0.25f;
	
	void LateUpdate () {
        targetX = (player1.position.x > player2.position.x) ? player1.position.x: player2.position.x;
        Vector3 moveTo = new Vector3(targetX, 0f, -10f);
        Vector3 smothedPosition = Vector3.Lerp(transform.position, moveTo, smooth);
        transform.position = smothedPosition;
	}
}
