using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Application.Quit();
        }
    }

    public void addScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
}
