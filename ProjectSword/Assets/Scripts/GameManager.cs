using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameIsOver = false;

    public GameObject gameOverUI;

    public string nextLevel = "Level02";
    public int LevelToReach = 2;

    public SceneFader sceneFader;

    void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {
        if (gameIsOver)
        {
            return;
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        Debug.Log("Game Over!");
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Level Won!");
        PlayerPrefs.SetInt("Level Reached", LevelToReach);
        sceneFader.FadeTo(nextLevel);
    }
}
