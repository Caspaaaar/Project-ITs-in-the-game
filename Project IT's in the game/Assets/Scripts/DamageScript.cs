using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScript : MonoBehaviour
{

    public Text GameOverText;
    public Text ScoreText;
    public string gameOverMessage;
    public string scoreMessage;
    public bool cheats = false;
    public GameOverScript gameOverScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        //Debug.Log("hit by " + col.name);
        if(col.tag == "Bullet")
        {
            ScoreManager.instance.health -= 1;
        }
        if(col.tag == "Missle")
        {
            ScoreManager.instance.health -= 2;
        }
        if(col.tag == "Arena")
        {
            ScoreManager.instance.health -= 2;
        }


        if(ScoreManager.instance.health <= 0)
        {

            gameOverScript.GameOver();

            //animation here

            gameObject.SetActive(false);
        }
    }

}
