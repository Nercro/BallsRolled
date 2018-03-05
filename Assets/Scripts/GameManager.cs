using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public Canvas GameplayCanvas;
    public Canvas GameOverCanvas;
    public Canvas winCanvas;
    public Text scoreText;
    public int Score = 0;
    public int winScore = 10;
    

    public void Awake()
    {
        Instance = this;
        GameOverCanvas.enabled = false;
        winCanvas.enabled = false;
        scoreText.text = "Score: " + Score;
    }

    public void AddScore(int value)
    {
        Score += value;
        scoreText.text = "Score: " + Score;
    }

    public void WinLevel()
    {
        winCanvas.enabled = true;
    }

    public void gameOver()
    {
        GameOverCanvas.enabled = true;
    }

  
}
