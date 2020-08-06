using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(GenerateMesh))]
public class PlaceObjects : MonoBehaviour {
    public TerrainController TerrainController { get; set; }
    public void Place() {
        for (int o = 0; o < TerrainController.PlaceableObjects.Length; o++) {
            int numObjects = 2;
            for (int i = 0; i < numObjects; i++) {
                int prefabType = o;
                Vector3 startPoint = RandomPointAboveTerrain(i);
                RaycastHit hit;
                if (Physics.Raycast(startPoint, Vector3.down, out hit) && (!TerrainController.Water || hit.point.y > TerrainController.Water.transform.position.y) && hit.collider.CompareTag("Terrain")) {
                    Quaternion orientation = Quaternion.Euler(Vector3.up);
                    RaycastHit boxHit;
                    if (Physics.BoxCast(startPoint, TerrainController.PlaceableObjects[prefabType].size, Vector3.down, out boxHit, orientation) && boxHit.collider.CompareTag("Terrain")) {
                        var CloneObj = Instantiate(TerrainController.PlaceableObjects[prefabType].prefab﻿, new Vector3(startPoint.x + i, hit.point.y, startPoint.z), orientation, transform);
                        CloneObj.GetComponent<Renderer>().material.color = RandomColor();
                        if (i == 0)
                        {
                            CloneObj.GetComponent<Renderer>().tag = "First Door";
                            CloneObj.GetComponent<Renderer>().name = "First Door";
                        }
                        else if(i == 1)
                        {
                            CloneObj.GetComponent<Renderer>().tag = "Second Door";
                            CloneObj.GetComponent<Renderer>().name = "Second Door";
                        }
                    }
                }

            }
        }
    }

    private Vector3 RandomPointAboveTerrain(int i) {
        return new Vector3(
            transform.position.x - 1 + i,
            transform.position.y + TerrainController.TerrainSize.y * 2,
            transform.position.z + TerrainController.TerrainSize.z / 2
        //transform.position.z + 10
        /*Random.Range(transform.position.x - TerrainController.TerrainSize.x / 2, transform.position.x + TerrainController.TerrainSize.x / 2),
        transform.position.y + TerrainController.TerrainSize.y * 2,
        Random.Range(transform.position.z - TerrainController.TerrainSize.z / 2, transform.position.z + TerrainController.TerrainSize.z / 2)*/
        );
    }
    private Color RandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 0.5f);
    }
}