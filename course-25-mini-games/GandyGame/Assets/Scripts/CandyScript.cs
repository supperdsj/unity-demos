using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CandyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameManager.instance.incScore();
            Destroy(gameObject);
        }else if (collider.gameObject.tag == "Boundary")
        {
            GameManager.instance.DecrLife();
            Destroy(gameObject);
        }
    }
}