using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour
{

    public Transform target;
    public float smooth = 0.25f;
    public Vector2 boundsMin;
    public Vector2 boundsMax;
    private Vector3 targetPosition;
    private Camera camera;

    private void Awake()
    {
        this.camera = this.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        targetPosition.x = Mathf.Clamp(target.position.x, boundsMin.x, boundsMax.x);
        targetPosition.y = Mathf.Clamp(target.position.y, boundsMin.y, boundsMax.y);
        Vector3 moveTo = new Vector3(targetPosition.x, targetPosition.y, -20f);
        Vector3 smothedPosition = Vector3.Lerp(transform.position, moveTo, smooth);
        transform.position = smothedPosition;
    }

    void OnDrawGizmosSelected()
    {
        this.camera = this.GetComponent<Camera>();
        Gizmos.color = Color.green;
        Vector2 min = new Vector2(-this.camera.orthographicSize * this.camera.aspect, -this.camera.orthographicSize) + boundsMin;
        Vector2 max = new Vector2(this.camera.orthographicSize * this.camera.aspect, this.camera.orthographicSize) + boundsMax;
        Gizmos.DrawLine(new Vector2(min.x, min.y), new Vector2(min.x, max.y));// left
        Gizmos.DrawLine(new Vector2(max.x, min.y), new Vector2(max.x, max.y));// right
        Gizmos.DrawLine(new Vector2(max.x, min.y), new Vector2(min.x, min.y));// bottom
        Gizmos.DrawLine(new Vector2(max.x, max.y), new Vector2(min.x, max.y));// top
    }
}
