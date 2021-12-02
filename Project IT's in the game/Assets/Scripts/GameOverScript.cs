using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverMenu;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GameOver()
    {

        if (ScoreManager.instance.health <= 0)
        {
            gameOverMenu.SetActive(true);
            
            scoreText.text += (Mathf.Round(ScoreManager.instance.TotalTimer * 10) / 10).ToString();
        }
    }
}
