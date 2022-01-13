using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TimerText;

    public int coins = 0;
    public int health = 5;
    public int shield = 0;
    public float totalTimer = 0;
    public float arenaScale;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        scoreText.text = coins.ToString() + " COINS";

        //get starting health on start
        if (PlayerPrefs.GetInt("startingHealth") != 0)
        {
            health = PlayerPrefs.GetInt("startingHealth");
        }
        else
        {
            health = 3;
            PlayerPrefs.SetInt("startingHealth", 3);
        }

        //compensation for damage on spawn
        health = health + 2;
    }

    public void AddCoins(int count) {
        coins += count;
        scoreText.text = coins.ToString() + " COINS";
    }

    // Update is called once per frame
    void Update()
    {
        totalTimer += Time.deltaTime;
        TimerText.text = Mathf.Round(totalTimer).ToString();
    }
}
