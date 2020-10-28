using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void Awake()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>().ScoreUp();
        Destroy(gameObject);
    }
}
