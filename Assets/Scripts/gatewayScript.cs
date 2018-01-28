using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatewayScript : MonoBehaviour {
    public GameObject[] m_buttons;
    public float moveTime;
    public float moveDistance;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    private float inverseMoveTime;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        inverseMoveTime = 1f / moveTime;
	}
	
    public void buttonPressed(int direction)
    {
        Debug.Log("Message Received");
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(0, moveDistance * direction);
        StartCoroutine(SmoothMovement(end));
    }

    protected IEnumerator SmoothMovement(Vector3 end)
    {
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while (sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(rigidBody.position, end, inverseMoveTime * Time.deltaTime);

            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            rigidBody.MovePosition(newPostion);

            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;

            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
