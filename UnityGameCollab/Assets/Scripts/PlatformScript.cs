using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript: MonoBehaviour
{
    [SerializeField] private Camera MainCamera;

    private float horizontalInput;
    public float speed = 8f;
    public Rigidbody2D PlatformRigidBody;
    public LogicManagerScript logic;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }

    void Update()
    {
        if (StateNameController.mouseControls && !logic.gameLost)
        {
            if (MainCamera.ScreenToWorldPoint(Input.mousePosition).x > -7 && MainCamera.ScreenToWorldPoint(Input.mousePosition).x < 7)
            {
                transform.position = new Vector3(MainCamera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, 0);
            }
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");

            PlatformRigidBody.velocity = new Vector2(horizontalInput * speed, 0f);

            if (transform.position.x > 7 || transform.position.x < -7)
            {
                if (transform.position.x > 7)
                    transform.position = new Vector3(7, transform.position.y, 0f);
                if (transform.position.x < 7)
                    transform.position = new Vector3(-7, transform.position.y, 0f);
            }
        }
    }
}
