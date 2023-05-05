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
        Spawn(3, 0);
    }
    private void Update()
    {
        //Spawning bricks based on a few conditions
        if (brickCount == 0)
        {
            if (timer < 1)
                timer += Time.deltaTime;

            else
            {
                lvl++;

                //Checking lvl value and spawning bricks based on the result
                switch (lvl)
                {
                    case 2:
                        Spawn(5, 0);
                        break;
                    case 3:
                        Spawn(8, 0);
                        break;
                    case 4:
                        Spawn(3, 1);
                        Spawn(8, 0);
                        break;
                    case 5:
                        Spawn(5, 1);
                        Spawn(8, 0);
                        break;
                    case 6:
                        Spawn(8, 1);
                        Spawn(8, 0);
                        break;
                }

                timer = 0;
            }
        }
    }

    //Method for spawning bricks
    private void Spawn(int bricksOnSide, int verticalOffset)
    {
        for (int i = 0; i < bricksOnSide; i++)
        { 
            Instantiate(brick, transform.position - new Vector3(i + 0.5f, verticalOffset, 0f), transform.rotation);
            Instantiate(brick, transform.position + new Vector3(i + 0.5f, -verticalOffset, 0f), transform.rotation);
        }
        brickCount += bricksOnSide * 2;
    }
}
