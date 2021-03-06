﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xInput;
    private SpriteRenderer sprite;
    private int score = 0;
    public float speed = 5f;
    public Text scoreText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        if (xInput < 0)
        {
            sprite.flipX = true;
        }else if (xInput > 0)
        {
            sprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * (xInput * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = score.ToString();
            // Destroy(gameObject);
            Invoke(nameof(Restart),2f);
            // Restart();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene("Game");
        score = 0;
    }
}