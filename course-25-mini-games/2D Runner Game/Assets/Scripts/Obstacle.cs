using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool moving = true;
    [SerializeField] private float moveSpeed = 6;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x <= -15f)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            rb.velocity = Vector2.left * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}