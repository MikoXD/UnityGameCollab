using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BallRigidBody;
    [SerializeField] private Transform Platform;

    public LogicManagerScript logicManager;

    public TrailRenderer ballTrailRenderer;
    public float ballSpeed = 10;
    public float bounceAngleMultiplier = 5;

    void Start()
    {
        //Give the ball initial speed
        BallRigidBody.velocity = new Vector2(-5, 5);

        //Get LogicManagerScript for later references
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();

        //Toogles off the TrailRenderer component
        ballTrailRenderer.enabled = false;
    }

    private void Update()
    {
        //Correcting ball velocity if it is different to ballSpeed
        if (BallRigidBody.velocity.magnitude != ballSpeed && !logicManager.gameLost)
        {
            BallRigidBody.velocity = BallRigidBody.velocity.normalized * ballSpeed;
            //Debug.Log("Ball velocity set back to " + ballSpeed);
        }

        //Correcting ball vector if it's horizontal (olr close to)
        if (Math.Abs(BallRigidBody.velocity.y) < 0.5 && !logicManager.gameLost)
        { 
            BallRigidBody.velocity = new Vector2(BallRigidBody.velocity.x, Math.Abs(BallRigidBody.velocity.y) + 1);
            Debug.Log("Ball vector corrected");
        }

        //Game over when ball is below the visible area
        if (transform.position.y <= -5.5)
            logicManager.Defeat(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
            //the ball's bounce angle depends on place where it hit the platform
            BallRigidBody.velocity = new Vector2((transform.position.x - Platform.position.x) * bounceAngleMultiplier, BallRigidBody.velocity.y);
    }
}
