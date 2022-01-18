using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScript : MonoBehaviour
{
    public string gameOverMessage;
    public string scoreMessage;
    public GameOverScript gameOverScript;
    private CircleCollider2D playerCollider;
    private MovementScript movementScript;


    // Start is called before the first frame update
    void Start()
    {
        playerCollider = gameObject.GetComponent<CircleCollider2D>();
        movementScript = gameObject.GetComponent<MovementScript>();
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
        else if(col.tag == "Missle")
        {
            ScoreManager.instance.health -= 2;
        }
        else if(col.tag == "Heart")
        {
            ScoreManager.instance.health += 1;
        }


        if(ScoreManager.instance.health <= 0)
        {

            gameOverScript.GameOver();

            //animation here

            gameObject.SetActive(false);
        }

    }

    public void fall()
    {
        StartCoroutine(shrink());
    }

    IEnumerator shrink()
    {
        playerCollider.enabled = false;
        movementScript.enabled = false;

        for (float i = 1f; i >= 0; i -= 0.03f)
        {
            yield return new WaitForSeconds(0.01f);
            gameObject.transform.localScale = new Vector3(i, i, 1);
        }

        ScoreManager.instance.health -= 2;

        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.position = new Vector3(0, 0, 0);
        movementScript.enabled = true;

        yield return new WaitForSeconds(0.5f);

        playerCollider.enabled = true;
    }

}
