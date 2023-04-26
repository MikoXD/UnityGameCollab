using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rb;
    public float ballSpeed = 10;

    void Start()
    {
        rb.velocity = new Vector2(-5, 5);
    }
    private void Update()
    {
        if (rb.velocity.magnitude != ballSpeed)
        {
            rb.velocity = rb.velocity.normalized * ballSpeed;
        }
    }
}
