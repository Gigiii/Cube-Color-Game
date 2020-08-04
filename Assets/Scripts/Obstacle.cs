using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public Material CubeMaterial;
    private void OnTriggerEnter(Collider collider) {
        if (!collider.CompareTag("Player"))
        {
            if (collider.gameObject.GetComponent<Renderer>().material.color == CubeMaterial.color)
            {
                collider.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
                Debug.Log("Color Changed");
            }
            else if(collider.gameObject.GetComponent<Renderer>().material.color == gameObject.GetComponent<Renderer>().material.color)
            {
                collider.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            }else
            {
                collider.gameObject.GetComponent<Cube_Movement>().enabled = false;
                collider.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
                Debug.Log("haha speed go brr");
            }
            return;
        }        
    }
}
