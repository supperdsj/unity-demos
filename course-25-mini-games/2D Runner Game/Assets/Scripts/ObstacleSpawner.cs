using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;
    public GameObject[] obstacles;
    public bool gameOver = false;

    public float minSpawnTime = 2f;
    public float maxSpawnTime = 5f;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(nameof(Spawn));
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2f);
        while (!gameOver)
        {
            float waitTime = Random.Range(minSpawnTime,maxSpawnTime);
            SpawnObstacle();
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstacles[Random.Range(0,obstacles.Length)], transform.position, Quaternion.identity);
    }
}