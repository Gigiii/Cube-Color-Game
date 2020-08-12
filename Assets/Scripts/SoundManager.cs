using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }
    public AudioSource swoosh;
    public AudioSource collision;
    public AudioSource click;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void RunSound(string SoundName)
    {
        if (SoundName == "swoosh")
        {
            swoosh.Play();
        }
        else if (SoundName == "collision")
        {
            collision.Play();
        }
        else if (SoundName == "click")
        {
            click.Play();
        }
        else
        {
            Debug.Log("Error, sound effect not found");
        }
    }
}
