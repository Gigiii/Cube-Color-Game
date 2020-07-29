using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Cube_Movement : MonoBehaviour
{
    public Vector3 position;
    float zSpeed = 0;
    void Update()
    {
        if(zSpeed < 5)
        {
            zSpeed += 0.01f;
        }
        Vector3 NewPosition = transform.position;
        NewPosition.z += (zSpeed + 1f) * Time.deltaTime;
        transform.position = NewPosition;
    }
}
