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
        //Collision with a ball
        if (collision.gameObject.layer == 3)
        {
            logicManager.Defeat(1);
            return;
        }
        
        Destroy(collision.gameObject);
    }
}
