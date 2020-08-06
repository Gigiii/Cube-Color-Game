using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideGameOver : MonoBehaviour
{
    public bool ShowGameOver = false;
    public GameObject Panel;
    void Start()
    {
        if (ShowGameOver == false)
        {
            Panel.SetActive(false);
        }
    }
    private void Update()
    {
        if (ShowGameOver == true)
        {
            Panel.SetActive(true);
        }
    }
}
