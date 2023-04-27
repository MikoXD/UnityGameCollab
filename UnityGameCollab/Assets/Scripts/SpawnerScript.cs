using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject brick;

    public int brickCount = 1;
    public int lvl = 1;
    private float timer = 0;

    private void Start()
    {
        Spawn1(3);
    }
    private void Update()
    {
        if (brickCount == 0)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime;
            }

            if (timer >= 1)
            {
                lvl++;

                switch (lvl)
                {
                    case 2:
                        Spawn1(5);
                        break;
                    case 3:
                        Spawn1(8);
                        break;
                    case 4:
                        Spawn2(3);
                        Spawn1(8);
                        break;
                    case 5:
                        Spawn2(5);
                        Spawn1(8);
                        break;
                    case 6:
                        Spawn2(8);
                        Spawn1(8);
                        break;
                }

                timer = 0;
            }
        }
    }
    private void Spawn1(int bricksOnSide)
    {
        for (int i = 0; i < bricksOnSide; i++)
        {
            if (i != 0)
            {
                Instantiate(brick, transform.position - new Vector3(i + 0.5f, 0f, 0f), transform.rotation);
                Instantiate(brick, transform.position + new Vector3(i + 0.5f, 0f, 0f), transform.rotation);
            }
            else
            {
                Instantiate(brick, transform.position - new Vector3(0.5f, 0f, 0f), transform.rotation);
                Instantiate(brick, transform.position + new Vector3(0.5f, 0f, 0f), transform.rotation);
            }
        }
        brickCount = bricksOnSide * 2;
    }
    private void Spawn2(int bricksOnSide)
    {
        for (int i = 0; i < bricksOnSide; i++)
        {
            if (i != 0)
            {
                Instantiate(brick, transform.position - new Vector3(i + 0.5f, 1f, 0f), transform.rotation);
                Instantiate(brick, transform.position + new Vector3(i + 0.5f, -1f, 0f), transform.rotation);
            }
            else
            {
                Instantiate(brick, transform.position - new Vector3(0.5f, 1f, 0f), transform.rotation);
                Instantiate(brick, transform.position + new Vector3(0.5f, -1f, 0f), transform.rotation);
            }
        }
        brickCount = bricksOnSide * 2;
    }
}
