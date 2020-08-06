using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class Cube_Movement : MonoBehaviour
{
    public float speed;
    Vector3 forwardRotationPoint;
    Vector3 backRotationPoint;
    Vector3 leftRotationPoint;
    Vector3 rightRotationPoint;
    Bounds bounds;
    public int RollAmount;
    bool rolling;
    private Vector2 initialPos;
    public Vector3 position;
    public float zSpeed;
    void Start()
    {
        bounds = GetComponent<MeshRenderer>().bounds;
        leftRotationPoint = new Vector3(-bounds.extents.x, -bounds.extents.y, 0);
        rightRotationPoint = new Vector3(bounds.extents.x, -bounds.extents.y, 0);
    }
    void Update()
    {
        Vector3 NewPosition = transform.position;
        NewPosition.z += (zSpeed + 1f) * Time.deltaTime;
        transform.position = NewPosition;
        if (Input.GetMouseButtonDown(0))
        {
            initialPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Calculate(Input.mousePosition);
        }
    }
    void Calculate(Vector3 finalPos)
    {
        float disX = Mathf.Abs(initialPos.x - finalPos.x);
        float disY = Mathf.Abs(initialPos.y - finalPos.y);
        if (disX > 0)
        {
            if (disX > disY)
            {
                if (rolling)
                {
                    return;
                }
                if (initialPos.x > finalPos.x)
                {
                    if (RollAmount < 1)
                    {
                        StartCoroutine(Roll(leftRotationPoint));
                        RollAmount += 1;
                    }
                }
                else
                {
                    if (RollAmount > -1)
                    {
                        StartCoroutine(Roll(rightRotationPoint));
                        RollAmount -= 1;
                    }
                }
            }

        }
    }
    private IEnumerator Roll(Vector3 rotationPoint)
    {
        Vector3 point = transform.position + rotationPoint;
        Vector3 axis = Vector3.Cross(Vector3.up, rotationPoint).normalized;
        float angle = 90;
        float a = 0;
        rolling = true;

        while (angle > 0)
        {
            a = Time.deltaTime * speed;
            transform.RotateAround(point, axis, a);
            angle -= a;
            yield return null;
        }
        transform.RotateAround(point, axis, angle);
        rolling = false;
    }
}
