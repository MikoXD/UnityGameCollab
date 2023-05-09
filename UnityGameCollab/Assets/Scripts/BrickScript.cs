using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public SpawnerScript spawner;
    public LogicManagerScript logicManager;
    public GameObject slowMotionPowerUp;
    public Vector2 brickSize;

    private void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerScript>();
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();

        brickSize = GetComponent<BoxCollider2D>().bounds.size;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Collision with the ball
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
            spawner.brickCount--;
        }

        //Spawning PowerUps
        int spawningChance = Random.Range(1, 11);

        switch(spawningChance)
        {
            //Slow motion power up
            case 1:
                Instantiate(slowMotionPowerUp, transform.position, transform.rotation);
                break;
        }
    }
}
