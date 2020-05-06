using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setHighscore : MonoBehaviour
{
    int highscore;
    int score;
    public Text scoreDisplay;
    public Text highscoreDisplay;
    public Text lastHighscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = PlayerPrefs.GetInt("score", 0);
        Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
        if (score > highscore)
        {
            highscoreDisplay.text = "NEW HIGHSCORE";
            if (score > highscore)
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        highscore = PlayerPrefs.GetInt("highscore", 0);
        lastHighscore.text = highscore.ToString();
    }
}
