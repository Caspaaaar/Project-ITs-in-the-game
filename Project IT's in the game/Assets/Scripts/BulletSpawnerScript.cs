using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawnerScript : MonoBehaviour
{

    public GameObject bullet;
    public float fireRate;
    public float distance;
    public float maxOffset;
    public float increaseTempo;
    private float duration;
    public float totalDuration;
    public Text txt;

    public int currentPattern = 1;
    private int newPattern = 1;
    private int patterns = 2;
    public float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        //dit is een deel van de berekening die zorgt dat de kogels meer langs het midden gaan
        maxOffset = Mathf.Sqrt(maxOffset);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //tijd regeling
        totalDuration += Time.deltaTime;
        duration += (Time.deltaTime * (totalDuration/increaseTempo));

        if(duration > fireRate)
        {

            //reset current timer
            duration = 0;

            switch (currentPattern)
            {
                case 1:

                    //rotate to make bullet come from random direction
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360.0f)));

                    //create bullet with offset
                    Instantiate(bullet, (transform.right * -distance) + (transform.up * Random.Range(-maxOffset, maxOffset) * Random.Range(-maxOffset, maxOffset)), gameObject.transform.rotation);

                    break;
                case 2:
                    //make bullet come from angle based on time smoothly
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (totalDuration * 60)%360));

                    //spawn bullet straight through the middle
                    Instantiate(bullet, transform.right * -distance, transform.rotation);

                    break;
            }

            


        }

        //set time to visible timer
        txt.text = Mathf.RoundToInt(totalDuration).ToString();
    }

    void ChangePattern()
    {
        while(newPattern == currentPattern)
        {
            newPattern = Random.Range(1, patterns);
        }
        duration = -cooldown;

        Debug.Log(newPattern);
    }
}
