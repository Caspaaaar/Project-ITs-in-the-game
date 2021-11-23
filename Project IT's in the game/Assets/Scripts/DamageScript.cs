using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScript : MonoBehaviour
{

    public int health;
    public Text txt;

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
            health -= 1;
        }
        if(col.tag == "Missle")
        {
            health -= 2;
        }
        if(col.tag == "Arena")
        {
            health -= 2;
        }

        UpdateHud();

        if(health <= 0)
        {
            txt.text += " You died";
            Destroy(gameObject);
        }
    }

    public void UpdateHud()
    {
        txt.text = health.ToString();
    }
}
