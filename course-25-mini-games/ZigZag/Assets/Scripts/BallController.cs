using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    public GameObject particle;
    private bool started = false;
    private Rigidbody rb;
    private bool gameOver = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        started = false;
        gameOver = false;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                started = true;
                rb.velocity = new Vector3(speed, 0, 0);
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (!Physics.Raycast(transform.position, Vector3.down, 5f))
        {
            gameOver = true;
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("diamond"))
        {
            GameObject p = Instantiate(particle, collider.gameObject.transform.position, Quaternion.identity);
            Destroy(collider.gameObject);
            Destroy(p, 1f);
        }
    }
}