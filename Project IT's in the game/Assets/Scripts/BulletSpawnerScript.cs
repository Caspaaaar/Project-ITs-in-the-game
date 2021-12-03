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

    public int currentPattern = 1;
    private readonly int patterns = 2;
    public float cooldown;
    public float patternTime;
    private float patternCount = 0;
    public float changeChance;

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
        duration += (Time.deltaTime * (Mathf.Pow(ScoreManager.instance.totalTimer, increaseTempo)));

        if(duration > fireRate)
        {


            //reset current timer
            duration = 0;

            if (Mathf.Floor(ScoreManager.instance.totalTimer / patternTime) > patternCount)
            {
                patternCount = patternCount + 1;
                ChangePattern();
            }


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
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (ScoreManager.instance.totalTimer * 60)%360));

                    //spawn bullet straight through the middle
                    Instantiate(bullet, transform.right * -distance, transform.rotation);

                    break;
            }

            

        }

    }

    void ChangePattern()
    {
        if (Random.value <= changeChance)
        {
            int temp = currentPattern;
            while(currentPattern == temp)
            {
                currentPattern = Random.Range(1, patterns + 1);
            }

            duration = -cooldown;
            
        }
    }
}
