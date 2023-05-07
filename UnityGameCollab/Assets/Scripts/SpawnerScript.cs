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

                switch (lvl)
                {
                    case 1:
                        SpawnBricks(3, 0);
                        break;
                    case 2:
                        SpawnBricks(5, 0);
                        break;
                    case 3:
                        SpawnBricks(8, 0);
                        break;
                    case 4:
                        SpawnBricks(3, 1);
                        SpawnBricks(8, 0);
                        break;
                    case 5:
                        SpawnBricks(5, 1);
                        SpawnBricks(8, 0);
                        break;
                    case 6:
                        SpawnBricks(8, 1);
                        SpawnBricks(8, 0);
                        break;
                }

                timer = 0;
            }
        }
    }
    private void SpawnBricks(int bricksOnSide, int verticalOffset)
    {
        for (int i = 0; i < bricksOnSide; i++)
        { 
            Instantiate(brick, transform.position - new Vector3(i + 0.5f, verticalOffset, 0f), transform.rotation);
            Instantiate(brick, transform.position + new Vector3(i + 0.5f, -verticalOffset, 0f), transform.rotation);
        }
        brickCount += bricksOnSide * 2;
    }
}
