using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour
{
    public SpawnerScript spawn;

    private void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
            spawn.brickCount--;
        }
    }
}
