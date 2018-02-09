using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform[] targets;
    public float smooth = 0.25f;
    private float targetX;

    void LateUpdate()
    {
        float targetX = 0;
        foreach (Transform target in targets)
        {
            targetX = Mathf.Max(targetX, target.position.x);
        }
        Vector3 moveTo = new Vector3(targetX, 0f, -20f);
        Vector3 smothedPosition = Vector3.Lerp(transform.position, moveTo, smooth);
        transform.position = smothedPosition;
    }
}
