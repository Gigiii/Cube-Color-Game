using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Obstacle : MonoBehaviour {
    public Material CubeMaterial;
    [SerializeField]
    static int TerrainZNum = 1;
    [SerializeField]    
    static int Score = 0;
    private void OnTriggerEnter(Collider collider) {
        if (!collider.CompareTag("Player"))
        {
            if (collider.gameObject.GetComponent<Renderer>().material.color == CubeMaterial.color)
            {
                collider.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
                Debug.Log("Color Changed");
                GameObject tile = GameObject.Find("Terrain Thingy [0 , 1]");
                Debug.Log(tile);
                int doornum = Random.Range(0, 2);
                Debug.Log(doornum);
                Transform door = null;
                if (doornum == 0)
                {
                    door = tile.transform.Find("First Door");
                }else if(doornum == 1)
                {
                    door = tile.transform.Find("Second Door");
                }
                if(door != null)
                {
                    Debug.Log("The door is not a lie");
                }else
                {
                    Debug.Log("The door is a lie!");    
                }
                door.GetComponent<Renderer>().material.color = collider.gameObject.GetComponent<Renderer>().material.color;
                GameObject.FindWithTag("Cube").GetComponent<Cube_Movement>().zSpeed += 1;
            }
            else if(collider.gameObject.GetComponent<Renderer>().material.color == gameObject.GetComponent<Renderer>().material.color)
            {
                collider.gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0.8f);
                Debug.Log("Color Changed");
                Debug.Log($"TerrainZNum = {TerrainZNum}");
                GameObject tile = GameObject.Find($"Terrain Thingy [0 , {TerrainZNum}]");
                Debug.Log(tile);
                int doornum = Random.Range(0, 2);
                Debug.Log(doornum);
                Transform door = null;
                if (doornum == 0)
                {
                    door = tile.transform.Find("First Door");
                }
                else if (doornum == 1)
                {
                    door = tile.transform.Find("Second Door");
                }
                if (door != null)
                {
                    Debug.Log("The door is not a lie");
                }
                else
                {
                    Debug.Log("The door is a lie!");
                }
                door.GetComponent<Renderer>().material.color = collider.gameObject.GetComponent<Renderer>().material.color;
                GameObject.FindWithTag("Cube").GetComponent<Cube_Movement>().zSpeed += 1;
            }
            else
            {
                collider.gameObject.GetComponent<Cube_Movement>().enabled = false;
                collider.gameObject.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
                Debug.Log("haha speed go brr");
                Obstacle.TerrainZNum = 0;
                Obstacle.Score = -1;
                collider.gameObject.GetComponent<Cube_Movement>().RollAmount = 0;
                GameObject.FindWithTag("GameOver").GetComponent<HideGameOver>().ShowGameOver = true;

            }
            Obstacle.TerrainZNum += 1;
            GameObject.FindWithTag("MainCamera").GetComponent<CameraFollow>().smoothSpeed -= 0.004f;
            Obstacle.Score += 1;
            GameObject.FindWithTag("Score").GetComponent<ScoreCount>().score.text = $"{Score}";
        }

    }
}
