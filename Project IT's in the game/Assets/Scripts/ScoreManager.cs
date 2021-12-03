using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text TimerText;

    public int coins = 0;
    public int health = 5;
    public float TotalTimer = 0;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        scoreText.text = coins.ToString() + " coins";

        //compensation for damage on spawn
        health = health + 2;
    }

    public void AddCoin() {
        coins += 1;
        scoreText.text = coins.ToString() + " coins";
    }

    // Update is called once per frame
    void Update()
    {
        TotalTimer += Time.deltaTime;
        TimerText.text = Mathf.Round(TotalTimer).ToString();
    }
}
