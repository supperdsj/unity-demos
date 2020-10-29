using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int score = 0;
    private bool gameOver = false;
    public Text scoreText;
    private int lives = 3;
    public GameObject livePanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void incScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void DecrLife()
    {
        if (lives > 0)
        {
            lives--;
            print(lives);
            livePanel.transform.GetChild(lives).gameObject.SetActive(false);
        }
        else
        {
            print("game over");
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        CandySpawner.instance.StopSpawningCandies();
        GameObject.Find("Player").GetComponent<PlayerController>().canMove=false;
        // PlayerController.
    }
}