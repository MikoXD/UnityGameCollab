using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SceenScript : MonoBehaviour
{
    private LogicManagerScript logicManager;
    public int ballsNumber = 1;

    private void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicManagerScript>();
        ballsNumber = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 3)
        {
            ballsNumber--;

            if (ballsNumber == 0)
                logicManager.Defeat(1);

            return;
        }
        
        Destroy(collision.gameObject);
    }
}
