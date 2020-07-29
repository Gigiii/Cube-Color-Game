using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Cube_Movement : MonoBehaviour
{
    float Speed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Speed < 25)
        {
            Speed += (float)0.01;
        }
        else
        {

        }
        Vector3 NewPosition = transform.position;
        NewPosition.z += (Speed + 1f) * Time.deltaTime;
        transform.position = NewPosition;
   //     transform.position.x += (new Vector3(0, .5f, 0) * Time.deltaTime)*2;
    }
}
