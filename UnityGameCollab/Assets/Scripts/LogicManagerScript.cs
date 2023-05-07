using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public int playerHighscore;
    public string highScoreFilePath;
    public string highScoreFileName;
    public bool gameLost = false;
    public Text scoreText;
    public Text GameOverReasonText;
    public Text GameOverScoreText;
    public Text GameOverHighscoreText;
    public GameObject GameOverParent;
    public GameObject ScoreText;
    public StreamWriter highScoreFileWriter;
    public StreamReader highScoreFileReader;
    // Start is called before the first frame update
    void Start()
    {
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

            highScoreFileWriter.WriteLine(playerScore);
            Debug.Log("Score " + playerScore + " written to file " + highScoreFileName + " in " + highScoreFilePath);

            highScoreFileWriter.Close();
            Debug.Log("Write-Closed file " + highScoreFileName + " in " + highScoreFilePath);

            highScoreFileReader = File.OpenText(highScoreFilePath);
            Debug.Log("Read-Opened file " + highScoreFileName + " in " + highScoreFilePath);

            List<string> stringScores = File.ReadAllLines(highScoreFilePath).ToList();
            List<int> intScores = stringScores.ConvertAll(int.Parse);

            playerHighscore = intScores.Max();

            GameOverHighscoreText.text = "Highscore: " + playerHighscore;

            highScoreFileReader.Close();
            Debug.Log("Read-Closed file " + highScoreFileName + " in " + highScoreFilePath);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
