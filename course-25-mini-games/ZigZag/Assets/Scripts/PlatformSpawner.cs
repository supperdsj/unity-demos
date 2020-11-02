using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
    private Vector3 lastPos;
    private float size;
    public GameObject platform;
    public GameObject diamond;
    public bool gameOver;


    private void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

        InvokeRepeating("SpawnPlatforms", 2f, 0.2f);
    }

    private void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        SpawnDiamond(pos);
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        SpawnDiamond(pos);
    }

    void SpawnDiamond(Vector3 pos)
    {
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
}