using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class CubeSideMovement : MonoBehaviour
{
    public Vector3 position;
    float Speed = 0;
    float MaxSpeed = 10;
    float Acceleration = 10;
    float Deceleration = 10; 
    
    void Start() 
    { 
        transform.position = position; 
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey("left")) && (Speed < MaxSpeed)) Speed = Speed - Acceleration * Time.deltaTime;
        else if ((Input.GetKey("right")) && (Speed > -MaxSpeed)) Speed = Speed + Acceleration * Time.deltaTime;
        else
        {
            if (Speed > Deceleration * Time.deltaTime) Speed = Speed - Deceleration * Time.deltaTime;
            else if (Speed < -Deceleration * Time.deltaTime) Speed = Speed + Deceleration * Time.deltaTime;
            else
                Speed = 0;
        }
        position.x = transform.position.x + Speed * Time.deltaTime;
        transform.position = position;
    }
}