using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverMenu : MonoBehaviour
{
    private int score;
    public Text scoreText;
    private float time;
    public Text timeText;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score: " + score.ToString();
        time = PlayerPrefs.GetFloat("Time");
        timeText.text = "Time: " + time.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("UGS");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

}

