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

    void Update()
    {
        if (DamageScript.health == 1)
        {
            heart1.GetComponent<Image>().enabled = true;
            heart2.GetComponent<Image>().enabled = false;
            heart3.GetComponent<Image>().enabled = false;
        }
        else if (DamageScript.health == 2)
        {
            heart1.GetComponent<Image>().enabled = true;
            heart2.GetComponent<Image>().enabled = true;
            heart3.GetComponent<Image>().enabled = false;
        }
        else if (DamageScript.health == 3)
        {
            heart1.GetComponent<Image>().enabled = true;
            heart2.GetComponent<Image>().enabled = true;
            heart3.GetComponent<Image>().enabled = true;
        }
        else if (DamageScript.health <= 0)
        {
            heart1.GetComponent<Image>().enabled = false;
            heart2.GetComponent<Image>().enabled = false;
            heart3.GetComponent<Image>().enabled = false;
        }
    }
}
