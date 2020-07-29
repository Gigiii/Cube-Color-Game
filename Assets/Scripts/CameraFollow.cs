using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.25f;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        Vector3 DesiredPosition = target.position + offset;
        transform.position = DesiredPosition;
    }

}
