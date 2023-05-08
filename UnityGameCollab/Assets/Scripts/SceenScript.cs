using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceenScript : MonoBehaviour
{
    private LogicManagerScript logicManager;

    private void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        if (collision.gameObject.layer == 3)
        {
            logicManager.Defeat(1);
        }
    }
}
