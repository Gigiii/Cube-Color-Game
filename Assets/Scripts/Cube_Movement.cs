using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Cube_Movement : MonoBehaviour
{
    public Vector3 position;
    float Speed = 0;
    float MaxSpeed = 10;
    float Acceleration = 10;
    float Deceleration = 10;
    float zSpeed = 0;
    void Update()
    {
        if(zSpeed < 5)
        {
            zSpeed += 0.01f;
        }
        if ((Input.GetKey("left")) && (Speed < MaxSpeed)) Speed = Speed - Acceleration * Time.deltaTime;
        else if ((Input.GetKey("right")) && (Speed > -MaxSpeed)) Speed = Speed + Acceleration * Time.deltaTime;
        else
        {
            if (Speed > Deceleration * Time.deltaTime) Speed = Speed - Deceleration * Time.deltaTime;
            else if (Speed < -Deceleration * Time.deltaTime) Speed = Speed + Deceleration * Time.deltaTime;
            else
                Speed = 0;
        }
        Vector3 NewPosition = transform.position;
        NewPosition.x = transform.position.x + Speed * Time.deltaTime;
        NewPosition.z += (zSpeed + 1f) * Time.deltaTime;
        transform.position = NewPosition;
    }
}
