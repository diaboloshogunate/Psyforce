using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;
    public float smooth = 0.25f;
    private float targetX;

    void LateUpdate()
    {
        Vector3 moveTo = new Vector3(target.position.x, target.position.y, -20f);
        Vector3 smothedPosition = Vector3.Lerp(transform.position, moveTo, smooth);
        transform.position = smothedPosition;
    }
}
