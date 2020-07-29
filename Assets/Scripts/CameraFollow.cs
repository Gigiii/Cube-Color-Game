using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.5f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 DesiredPosition = target.position + offset;
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, DesiredPosition, 1.1f *Time.deltaTime);
        transform.position = SmoothedPosition;
    }

}
