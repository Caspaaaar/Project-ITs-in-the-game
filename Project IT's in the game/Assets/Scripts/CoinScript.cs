using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
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
        if(col.tag == "Player")
        {
            ScoreManager.instance.AddCoins(1);

            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Arena")
        {
            StartCoroutine(shrink());
        }
    }

    IEnumerator shrink()
    {

        for (float i = 1f; i >= 0; i -= 0.03f)
        {
            yield return new WaitForSeconds(0.01f);
            gameObject.transform.localScale = new Vector3(i, i, 1);
        }

        Destroy(gameObject);
    }
}
