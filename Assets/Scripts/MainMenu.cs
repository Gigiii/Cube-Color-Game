using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SoundManager.Instance.RunSound("click");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        SoundManager.Instance.RunSound("click");
        Debug.Log("Quit");
        Application.Quit();
    }
    public void ReloadGame()
    {
        SoundManager.Instance.RunSound("click");
        SceneManager.LoadScene("Game");
    }
}