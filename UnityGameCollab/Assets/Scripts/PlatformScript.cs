using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlatformScript: MonoBehaviour
{
    private float horizontalAxisValue;
    public float platformSpeed;
    private float timer = 0f;
    public Rigidbody2D platformRigidbody2D;
    private bool slowMotionPowerUpOn = false;
    public float slowDown = 2;

    [SerializeField] private BallScript ballScript;

    private void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
    }
    void FixedUpdate()
    {
        //Timer for slow motion power up
        if (slowMotionPowerUpOn)
        {
            if (timer < 5)
                timer += Time.deltaTime;

            //After 5 seconds everything goes back to normal
            else
            {
                platformSpeed *= slowDown;
                ballScript.ballSpeed *= slowDown;
                ballScript.ballTrailRenderer.enabled = false;
                timer = 0f;
                slowMotionPowerUpOn = false;
                Debug.Log("Power Up ended");
            }
        }

        //Platform movement
        horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        platformRigidbody2D.velocity = new Vector2(horizontalAxisValue * platformSpeed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Checking which PowerUp hit the platform
        switch (collision.gameObject.layer)
        {
            //Slow motion power up
            case 7:

                Destroy(collision.gameObject);

                if (!slowMotionPowerUpOn)
                {
                    //Slowing everything down
                    platformSpeed /= slowDown;
                    ballScript.ballSpeed /= slowDown;
                    ballScript.ballTrailRenderer.enabled = true;
                }

                slowMotionPowerUpOn = true;
                timer = 0f;

                break;
        }
    }
}
