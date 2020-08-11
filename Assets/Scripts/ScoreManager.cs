using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text HighscoreText;
    public static ScoreManager Instance { get; set; }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void SetHighScore(int Score)
    { 
            int highscore = PlayerPrefs.GetInt("highscore");
            if (Score > highscore)
            {
                highscore = Score;
                PlayerPrefs.SetInt("highscore", highscore);
            }
            HighscoreText.text = $"highscore: {highscore}";
    }
}
