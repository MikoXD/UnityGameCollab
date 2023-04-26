using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject brick;
    public int brickCount;
    private int lvl = 1;

    private void Update()
    {
        if (brickCount == 0)
        {
            lvl++;
        }
    }
}
