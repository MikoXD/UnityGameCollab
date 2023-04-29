using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;

    public float ballSpeed = 10;
    private int debuger = 0;
    private Vector3 position;
    public LogicManagerScript logic;

    void Start()
    {
        rb.velocity = new Vector2(-5, 5);
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }
    private void Update()
    {
        if (rb.velocity.magnitude != ballSpeed)
        {
            rb.velocity = rb.velocity.normalized * ballSpeed;
        }

        if (transform.position.y == position.y)
        {
            if (debuger == 300)
            {
                rb.velocity = new Vector2(0, -10);
                debuger = 0;
            }
            debuger++;
        }

        if (transform.position.y <= -5.5)
        {
            logic.defeat();
        }

        position = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            rb.velocity = new Vector2((transform.position.x - player.position.x) * 2, rb.velocity.y);
        }
    }
}
