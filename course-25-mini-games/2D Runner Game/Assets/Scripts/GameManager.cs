using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject gameOverPanel;
    public Text scoreText;
    private int score = 0;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        StopScrolling();
        StopObstacleMoving();
        gameOverPanel.SetActive(true);
    }

    public void StopScrolling()
    {
        TextureScroll[] tsArr = FindObjectsOfType<TextureScroll>();
        foreach (var ts in tsArr)
        {
            ts.scroll = false;
        }
    }

    public void StopObstacleMoving()
    {
        Obstacle[] oArr = FindObjectsOfType<Obstacle>();
        foreach (var o in oArr)
        {
            o.moving = false;
        }
    }

    public void IncScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    //
    // public void Restart()
    // {
    //     SceneManager.LoadScene("Game");
    // }
    // public void Menu()
    // {
    //     SceneManager.LoadScene("Menu");
    // }
}