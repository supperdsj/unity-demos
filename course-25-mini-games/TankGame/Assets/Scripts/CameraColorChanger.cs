using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraColorChanger : MonoBehaviour
{
    private float timer = 0;
    private Camera _camera;
    
    public float delay = 1f;
    public Color[] colors;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Start()
    {
    }

    void Update()
    {
        if (timer >= delay)
        {
            ChangeColor();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void ChangeColor()
    {
        int rand = Random.Range(0, colors.Length);
        _camera.backgroundColor = colors[rand];
    }
}