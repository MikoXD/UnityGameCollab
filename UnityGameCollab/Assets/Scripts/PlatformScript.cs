using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript: MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public Rigidbody2D rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, 0f);

        if (transform.position.x > 7 || transform.position.x < -7)
        {
            if (transform.position.x > 7)
                transform.position = new Vector3(7, transform.position.y, 0f);
            if (transform.position.x < 7)
                transform.position = new Vector3(-7, transform.position.y, 0f);
        }
    }
}
