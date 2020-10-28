using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public GameObject winText;
    public GameObject restartBtn;

    private void Awake()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Application.targetFrameRate = 60;
        }
    }

    void Update()
    {
        
    }

    public void ScoreUp()
    {
        score++;
        // if (!GameObject.FindObjectOfType<Ball>())
        if(score>=4)
        {
            Win();
        }
    }

    void Win()
    {
        winText.SetActive(true);
        restartBtn.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
