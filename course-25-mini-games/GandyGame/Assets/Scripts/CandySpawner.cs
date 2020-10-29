using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] private float maxPos;
    public GameObject[] candyies;
    [SerializeField] float spawnInterval = 3f;
    public static CandySpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        StartSpawningCandies();
    }

    void SpawnCandy()
    {
        int randCand = Random.Range(0, candyies.Length);
        float randomX = Random.Range(-maxPos, maxPos);
        Instantiate(candyies[randCand],
            new Vector3(randomX, transform.position.y, transform.position.z),
            Quaternion.identity);
    }

    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}