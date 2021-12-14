using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDamageScript : MonoBehaviour
{
    private void Update()
    {
        transform.localScale = new Vector3(ScoreManager.instance.shield + .9f, ScoreManager.instance.shield + .9f, 1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        //Debug.Log("hit by " + col.name);
        if (col.tag == "Bullet" || col.tag == "Missle")
        {
            ScoreManager.instance.shield -= 1;
        }
        else if (col.tag == "Shield")
        {
            ScoreManager.instance.shield += 1;
        }
        else if (col.tag == "Heart")
        {
            ScoreManager.instance.health += 1;
        }

    }
}
