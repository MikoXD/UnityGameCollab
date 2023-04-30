using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public bool gameLost = false;
    public GameObject GameOverParent;
    public GameObject ScoreText;
    public Text GameOverReasonText;
    public Text GameOverScoreText;
    public Text GameOverHighscoreText;
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

    public void defeat(int defeatReasonNumber)
    {
        if (!gameLost)
        {
            gameLost = true;

            switch (defeatReasonNumber)
            {
                case 1:
                    GameOverReasonText.text = "Ball fell out of the zone";
                    break;
            }

            GameOverScoreText.text = "Score: " + playerScore.ToString();

            GameOverParent.SetActive(true);
            ScoreText.SetActive(false);

            Debug.Log("DEFEAT");
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
