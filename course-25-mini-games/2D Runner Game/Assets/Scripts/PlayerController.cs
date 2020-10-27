using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float jumForce;

    private Animator animator;
    private bool grounded = false;
    public bool gameOver = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && grounded && !gameOver)
        {
            Jump();
        }
    }

    void Jump()
    {
        // if (rb.velocity.y == 0)
        grounded = false;
        animator.SetTrigger("Jump");
        rb.velocity = Vector2.up * jumForce;
        GameManager.instance.IncScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collider.gameObject);
            animator.Play("SantaDead");
            GameManager.instance.GameOver();
            gameOver = true;
        }
    }
}