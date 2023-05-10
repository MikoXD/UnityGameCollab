using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BallRigidBody;
    [SerializeField] public TrailRenderer ballTrailRenderer;
    [SerializeField] private PlatformScript platformScript;
    [SerializeField] private SceenScript screenScript;

    public LogicManagerScript logicManager;
    public float ballSpeed = 10f;
    public float bounceAngleMultiplier = 5f;
    public GameObject ballPrefab;
    public int randomVectorValue;
    public Vector2 parentBallVelocity = Vector2.zero;
    public bool didFirstBallSpawned = false;
    public int ballsToCreate = 0;
    public GameObject firstBall;
    public GameObject secondBall;

    void Start()
    {
        //Starting ball initial speed
        if (parentBallVelocity == Vector2.zero)
            BallRigidBody.velocity = new Vector2(-5, 5);

        //The initial speed for cloned balls
        else
            BallRigidBody.velocity = new Vector2(BallRigidBody.velocity.x, BallRigidBody.velocity.y + 1f);

        //Geting scripts for later references
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
        platformScript = GameObject.FindGameObjectWithTag("Platform").GetComponent<PlatformScript>();

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

        //Spawning balls if the conditions are met
        if (platformScript.ballCloningPowerUpOn)
        {
            if (ballsToCreate > 0)
                BallCloningPowerUp(ballsToCreate);
            else
                platformScript.ballCloningPowerUpOn = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
            //the ball's bounce angle depends on place where it hit the platform
            BallRigidBody.velocity = new Vector2((transform.position.x - platformScript.transform.position.x) * bounceAngleMultiplier, BallRigidBody.velocity.y);
    }
    public void SlowMotionPowerUp(bool slowingDownOrSpeedingUp)
    {
        switch (slowingDownOrSpeedingUp)
        {

            //Slowing down
            case true:

                ballSpeed /= platformScript.slowDown;
                ballTrailRenderer.enabled = true;

                /*
                    firstBall.GetComponent<BallScript>().ballSpeed /= platformScript.slowDown;
                    secondBall.GetComponent<BallScript>().ballSpeed /= platformScript.slowDown;
                    firstBall.GetComponent<TrailRenderer>().enabled = true;
                    secondBall.GetComponent<TrailRenderer>().enabled = true;
                */
                
                break;

            //Speeding up
            case false:

                ballSpeed *= platformScript.slowDown;
                ballTrailRenderer.enabled = false;

                /*
                    firstBall.GetComponent<BallScript>().ballSpeed *= platformScript.slowDown;
                    secondBall.GetComponent<BallScript>().ballSpeed *= platformScript.slowDown;
                    firstBall.GetComponent<TrailRenderer>().enabled = false;
                    secondBall.GetComponent<TrailRenderer>().enabled = false;
                */

                break;
        }
    }
    public void BallCloningPowerUp(int ballsToCreate)
    {
        parentBallVelocity = BallRigidBody.velocity;
        Instantiate(ballPrefab, transform.position, transform.rotation);
        Debug.Log("Ball cloned");

        screenScript.ballsNumber++;
        ballsToCreate--;
    }

    //Created this to solve the problems that have occured (not finished)
    public void BallCloningPowerUp2BallsVersion()
    {
        parentBallVelocity = BallRigidBody.velocity;

        firstBall = Instantiate(ballPrefab, transform.position, transform.rotation);
        secondBall = Instantiate(ballPrefab, transform.position, transform.rotation);

        firstBall.GetComponent<Rigidbody2D>().velocity = new Vector2(BallRigidBody.velocity.x, BallRigidBody.velocity.y + 1f);
        secondBall.GetComponent<Rigidbody2D>().velocity = new Vector2(BallRigidBody.velocity.x, BallRigidBody.velocity.y - 1f);

        Debug.Log("Ball cloned");

        screenScript.ballsNumber += 2;
    }
}
