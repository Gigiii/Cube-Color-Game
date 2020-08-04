using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    private void OnTriggerEnter(Collider collider) {
        if (!collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<Cube_Movement>().enabled = false;
            collider.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Debug.Log("haha speed go brr");
            return;
        }        
    }
}
