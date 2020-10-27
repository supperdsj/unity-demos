using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject target;
    public int score = 0;
    public Text scoreText;
    public GameObject gameOver;
    private bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        InvokeRepeating(nameof(Spawn), 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            CancelInvoke(nameof(Spawn));
            gameOver.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
        }
    }

    void Spawn()
    {
        float randX = Random.Range(-7f, 7f);
        float randY = Random.Range(-4f, 4f);

        Vector3 randPos = new Vector3(randX, randY, 0);

        Instantiate(target, randPos, Quaternion.identity);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score >= 5)
        {
            win = true;
        }
        print(score);
    }
}