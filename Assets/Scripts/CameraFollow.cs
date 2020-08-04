using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.3f;
    public Vector3 offset;
    private Vector3 Velocity = Vector3.zero;   

    void LateUpdate()
    {
        Vector3 DesiredPosition = target.position + offset;
        Vector3 SmoothedPosition = Vector3.SmoothDamp(transform.position, DesiredPosition,ref Velocity ,smoothSpeed);
        transform.position = SmoothedPosition;
    }

}
