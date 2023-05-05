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

    [SerializeField] private GameObject slowMotionPowerUp;
    [SerializeField] private BallScript ballScript;

    private void Start()
    {
        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallScript>();
    }
    void Update()
    {
        horizontalAxisValue = Input.GetAxisRaw("Horizontal");

        platformRigidbody2D.velocity = new Vector2(horizontalAxisValue * platformSpeed, 0f);

        if (transform.position.x > 7 || transform.position.x < -7)
        {
            if (transform.position.x > 7)
                transform.position = new Vector3(7, transform.position.y, 0f);
            if (transform.position.x < 7)
                transform.position = new Vector3(-7, transform.position.y, 0f);
        }

        if (slowMotionPowerUp.transform.position.y >= -5.5f)
            Destroy(slowMotionPowerUp);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Checking which PowerUp hit the platform
        switch (collision.gameObject.layer)
        {
            case 7:

                //Slowing everything down
                platformSpeed *= 0.5f;
                ballScript.ballSpeed *= 0.5f;
                ballScript.ballTrailRenderer.enabled = true;

                //After 5 seconds everything goes back to normal
                if (timer <= 5)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    platformSpeed *= 2;
                    ballScript.ballSpeed *= 2;
                    ballScript.ballTrailRenderer.enabled = false;
                }

                Destroy(collision.gameObject);

                break;
        }
    }
}
