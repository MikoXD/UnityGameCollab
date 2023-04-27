using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public SpawnerScript spawn;
    public SpawnerScript logic;

    private void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerScript>();
        logic = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
            spawn.brickCount--;
            logic.addScore(1);
        }
    }
}
