using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BallRigidBody;
    [SerializeField] private Transform Platform;

    public LogicManagerScript logic;

    public float ballSpeed = 10;
    public float bounceAngleMultiplier = 5;

    void Start()
    {
        //Give the ball initial speed
        BallRigidBody.velocity = new Vector2(-5, 5);
        //Get LogicManagerScript for later references
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }

    private void Update()
    {
        //Correcting ball velocity if it is different to ballSpeed
        if (BallRigidBody.velocity.magnitude != ballSpeed && !logic.gameLost)
        {
            BallRigidBody.velocity = BallRigidBody.velocity.normalized * ballSpeed;
            Debug.Log("Ball velocity set back to " + ballSpeed);
        }

        //Correcting ball vector if it's horizontal (olr close to)
        if (Math.Abs(BallRigidBody.velocity.y) < 0.5 && !logic.gameLost)
        { 
            BallRigidBody.velocity = new Vector2(BallRigidBody.velocity.x, Math.Abs(BallRigidBody.velocity.y) + 1);
            Debug.Log("Ball vector corrected");
        }

        //Game over when ball is below the visible area
        if (transform.position.y <= -5.5)
        {
            logic.defeat(1);
        }

        //Ball's velocity is set to 0 when game is lost
        if (logic.gameLost && BallRigidBody.velocity.magnitude != 0)
        {
            BallRigidBody.velocity = new Vector2(0, 0);
            Debug.Log("Ball velocity set to 0");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //the ball's bounce angle depends on place where it hit the platform
            BallRigidBody.velocity = new Vector2((transform.position.x - Platform.position.x) * bounceAngleMultiplier, BallRigidBody.velocity.y);
        }
    }
}
