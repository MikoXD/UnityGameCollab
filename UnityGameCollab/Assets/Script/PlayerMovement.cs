using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;

    [SerializeField] public Rigidbody rb;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontal * speed, 0f);

        if (transform.position.x >= 7 || transform.position.x <= -7)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
