using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public float gamingTime = 0;
    public float gamingTimeFromLastFrame;
    public int playerHighscore;
    public Text scoreText;
    public bool gameLost = false;
    public GameObject gameOverParent;
    public GameObject scoreTextObject;
    public Text gameOverReasonText;
    public Text gameOverScoreText;
    public Text gameOverHighscoreText;
    public Text gameOverText;
    public StreamWriter highScoreFileWriter;
    public StreamReader highScoreFileReader;
    public string highScoreFilePath;
    public string highScoreFileName;
    public Rigidbody2D ballRigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        //Creating the Scores.txt file
        highScoreFileName = "Scores.txt";
        highScoreFilePath = @"..\others\" + highScoreFileName;
        if (!File.Exists(highScoreFilePath))
        {
            highScoreFileWriter = File.CreateText(highScoreFilePath);
            Debug.Log("Created file " + highScoreFileName + " in " + highScoreFilePath);
        }
        else
        {
            highScoreFileWriter = new StreamWriter(highScoreFilePath, true);
            Debug.Log("Write-Opened file " + highScoreFileName + " in " + highScoreFilePath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
            Application.Quit();
    }
    private void FixedUpdate()
    {
        //Timer
        if (!gameLost)
        {
            gamingTime += Time.deltaTime;

            //Chcecking if the rounded value from last frame + 1 is equal to rounded value this frame
            if (Math.Round(gamingTimeFromLastFrame) + 1 == Math.Round(gamingTime))
            {
                AddScore(1);
                Debug.Log($"Player score: {playerScore}");
            }

            gamingTimeFromLastFrame = gamingTime;
        }
    }

    public void AddScore(int scoreToAdd = 1)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void Defeat(int defeatReasonNumber)
    {
        if (!gameLost)
        {
            gameLost = true;

            //Defeat reason
            switch (defeatReasonNumber)
            {
                case 1:
                    gameOverReasonText.text = "Ball fell out the zone";
                    gameOverText.color = Color.red;
                    break;
                case 2:
                    gameOverReasonText.text = "You won!";
                    gameOverText.color = Color.green;
                    break;
            }

            gameOverScoreText.text = $"Time: {playerScore}";

            gameOverParent.SetActive(true);
            scoreTextObject.SetActive(false);

            Debug.Log("DEFEAT");

            highScoreFileWriter.WriteLine(playerScore);
            Debug.Log($"Time {playerScore} written to file {highScoreFileName} in {highScoreFilePath}");

            highScoreFileWriter.Close();
            Debug.Log($"Write-Closed file {highScoreFileName} in {highScoreFilePath}");

            highScoreFileReader = File.OpenText(highScoreFilePath);
            Debug.Log($"Read-Opened file {highScoreFileName} in {highScoreFilePath}");

            List<string> stringScores = File.ReadAllLines(highScoreFilePath).ToList();
            List<int> intScores = stringScores.ConvertAll(int.Parse);

            playerHighscore = intScores.Max();

            gameOverHighscoreText.text = $"Best time: {playerHighscore}";

            highScoreFileReader.Close();
            Debug.Log($"Read-Closed file {highScoreFileName} in {highScoreFilePath}");

            if (ballRigidBody2D.velocity.magnitude != 0)
                ballRigidBody2D.velocity = Vector2.zero;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
}