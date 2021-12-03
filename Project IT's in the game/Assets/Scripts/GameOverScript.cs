using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverMenu;
    public Text scoreText;
    public Text gameOverText;
    public Text highscoreText;
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

        gameOverMenu.SetActive(true);

        score = (Mathf.Round(ScoreManager.instance.TotalTimer * 10) / 10);

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
            gameOverText.text = "Filthy Cheater!!!";
        }
        else if (highscore)
        {
            gameOverText.text = "New highscore!!!";
        }

        //maybe create random different game over messages like

        //game over, try again!
        //haha noob, game over!!
        // :D :D :D :(
    }
}
