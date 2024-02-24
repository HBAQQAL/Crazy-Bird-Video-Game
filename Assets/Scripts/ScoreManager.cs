using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    // create a text mwsh pro variable
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI highScore;
    private void Awake()
    {
        // check if the player has a high score
        if (PlayerPrefs.HasKey("highScore"))
        {
            // Retrieve the high score from PlayerPrefs and set it in highScoreText
            int highScoree = PlayerPrefs.GetInt("highScore");
            Debug.Log(highScoree);
            changeHS(highScoree);
            

        }
        else
        {
            PlayerPrefs.SetInt("highScore", 0);
            Debug.Log("no high score");

        }
    }
    // Start is called before the first frame update
  


    public void changeScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void changeHS(int score)
    {
        highScore.text = "HIGH SCORE : " +score.ToString();
        PlayerPrefs.SetInt("highScore", score);
    }
    
}
