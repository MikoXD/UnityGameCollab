using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    [SerializeField] private LogicManagerScript logicManagerScript;

    public int brickCount = 0;
    public int lvl = 1;
    private float timer = 0;

    private void Start()
    {
        logicManagerScript = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }
    private void Update()
    {
        if (brickCount == 0)
        {
            if (timer < 1)
            {
                timer += Time.deltaTime;
            }

            else
            {
                lvl++;
                //Levels
                switch (lvl)
                {
                    case 1:
                        SpawnBricks(3, 0);
                        break;
                    case 2:
                        SpawnBricks(5, 0);
                        break;
                    case 3:
                        SpawnBricks(7, 0);
                        break;
                    case 4:
                        SpawnBricks(3, 1);
                        SpawnBricks(7, 0);
                        break;
                    case 5:
                        SpawnBricks(5, 1);
                        SpawnBricks(7, 0);
                        break;
                    case 6:
                        SpawnBricks(7, 1);
                        SpawnBricks(7, 0);
                        break;
                    case 7:
                        SpawnBricks(3, 2);
                        SpawnBricks(7, 1);
                        SpawnBricks(7, 0);
                        break;
                    case 8:
                        SpawnBricks(5, 2);
                        SpawnBricks(7, 1);
                        SpawnBricks(7, 0);
                        break;
                    case 9:
                        SpawnBricks(7, 2);
                        SpawnBricks(7, 1);
                        SpawnBricks(7, 0);
                        break;
                    case 10:
                        SpawnBricks(5, 2);
                        SpawnBricks(3, 1);
                        SpawnBricks(7, 0);
                        break;
                    case 11:
                        logicManagerScript.Defeat(2);
                        break;
                }

                timer = 0;
            }
        }
    }
    //Spawning bricks from the middle to the sides
    private void SpawnBricks(int bricksOnSide, int verticalOffset)
    {
        for (int i = 0; i < bricksOnSide; i++)
        {
            Instantiate(brick, transform.position - new Vector3(i * (1.16f + 0.05f) + 0.58f + 0.025f, verticalOffset + 0.05f * verticalOffset, 0f), transform.rotation);
            Instantiate(brick, transform.position + new Vector3(i * (1.16f + 0.05f) + 0.58f + 0.025f, -verticalOffset - 0.05f * verticalOffset, 0f), transform.rotation);
        }
        brickCount += bricksOnSide * 2;
    }
}
