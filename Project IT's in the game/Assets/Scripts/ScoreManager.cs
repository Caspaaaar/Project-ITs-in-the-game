using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text TimerText;

    public int score = 0;
    public int health = 5;
    public float TotalTimer = 0;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString() + " coins";
    }

    public void AddPoint() {
        score += 1;
        scoreText.text = score.ToString() + " coins";
    }

    // Update is called once per frame
    void Update()
    {
        TotalTimer += Time.deltaTime;
        TimerText.text = Mathf.Round(TotalTimer).ToString();
    }
}
