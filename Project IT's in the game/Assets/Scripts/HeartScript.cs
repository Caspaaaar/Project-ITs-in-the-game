using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartScript : MonoBehaviour
{
    public DamageScript DamageScript;
    public int life;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    void Update()
    {
        if (ScoreManager.instance.health == 1)
        {
            heart1.GetComponent<Image>().enabled = true;
            heart2.GetComponent<Image>().enabled = false;
            heart3.GetComponent<Image>().enabled = false;
            heart4.GetComponent<Image>().enabled = false;
            heart5.GetComponent<Image>().enabled = false;
        }
        else if (ScoreManager.instance.health == 2)
        {
            heart1.GetComponent<Image>().enabled = true;
            heart2.GetComponent<Image>().enabled = true;
            heart3.GetComponent<Image>().enabled = false;
            heart4.GetComponent<Image>().enabled = false;
            heart5.GetComponent<Image>().enabled = false;
        }
        else if (ScoreManager.instance.health == 3)
        {
            heart1.GetComponent<Image>().enabled = true;
            heart2.GetComponent<Image>().enabled = true;
            heart3.GetComponent<Image>().enabled = true;
            heart4.GetComponent<Image>().enabled = false;
            heart5.GetComponent<Image>().enabled = false;
        }
        else if (ScoreManager.instance.health == 4)
        {
            heart1.GetComponent<Image>().enabled = true;
            heart2.GetComponent<Image>().enabled = true;
            heart3.GetComponent<Image>().enabled = true;
            heart4.GetComponent<Image>().enabled = true;
            heart5.GetComponent<Image>().enabled = false;
        }
        else if (ScoreManager.instance.health >= 5)
        {
            heart1.GetComponent<Image>().enabled = true;
            heart2.GetComponent<Image>().enabled = true;
            heart3.GetComponent<Image>().enabled = true;
            heart4.GetComponent<Image>().enabled = true;
            heart5.GetComponent<Image>().enabled = true;
        }
        else if (ScoreManager.instance.health <= 0)
        {
            heart1.GetComponent<Image>().enabled = false;
            heart2.GetComponent<Image>().enabled = false;
            heart3.GetComponent<Image>().enabled = false;
            heart4.GetComponent<Image>().enabled = false;
            heart5.GetComponent<Image>().enabled = false;
        }
    }
}