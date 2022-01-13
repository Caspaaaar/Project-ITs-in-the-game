using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverMenu;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI gameoverMessage;
    public bool cheated = false;
    private bool highscore = false;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GameOver()
    {
        ScoreManager.instance.TimerText.enabled=false;
        gameOverMenu.SetActive(true);

        score = (Mathf.Round(ScoreManager.instance.totalTimer * 10) / 10);

        scoreText.text += score;

        if(score > PlayerPrefs.GetFloat("highscore") && !cheated)
        {
            PlayerPrefs.SetFloat("highscore", score);
            highscore = true;
            highscoreText.enabled = false;
        }
        else
        {
            highscoreText.text += PlayerPrefs.GetFloat("highscore");
        }

        changeMessage();

        //maybe play sound?

        PlayerPrefs.SetInt("coins", ScoreManager.instance.coins);
        
    }

    public void changeMessage()
    {
        if (cheated)
        {
            gameoverMessage.text = "YOU FILTHY CHEATER";
        }
        else if (highscore)
        {
            gameoverMessage.text = "NEW HIGHSCORE";
        }
        else
        {
            switch (Random.Range(1, 4))
            {
                case 1:
                    gameoverMessage.text = "GAME OVER, TRY AGAIN!";
                    break;
                case 2:
                    gameoverMessage.text = "HAHA GG EZ NOOB";
                    break;
                case 3:
                    gameoverMessage.text = "HAHAHAHAHAHAHA";
                    break;
            }
        }
    
        //maybe create random different game over messages like
    
        //game over, try again!
        //haha noob, game over!!
        // :D :D :D :(
    }
}
