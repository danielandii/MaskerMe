using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    int highscore;

    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        Debug.Log(highscore);
    }
    private void Update()
    {
        // if (score > highscore)
        // {
        //     PlayerPrefs.SetInt("highscore", score);
        // }
        PlayerPrefs.SetInt("score", score);
        scoreDisplay.text = score.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("People"))
        {
            score++;
            // if (score++ > highscore)
            // {
            //     highscore = score;
            // }
        }
    }
}
