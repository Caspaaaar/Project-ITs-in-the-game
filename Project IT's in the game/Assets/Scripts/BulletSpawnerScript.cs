using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSpawnerScript : MonoBehaviour
{

    public GameObject bullet;
    public float fireRate;
    public float distance;
    public float increaseTempo;
    private float duration;

    public int currentPattern = 1;
    private readonly int patterns = 3;
    public float cooldown;
    public float patternTime;
    private float patternCount = 0;
    public float changeChance;

    // Start is called before the first frame update
    void Start()
    {

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
                    Instantiate(bullet, (transform.right * -distance) + (transform.up * Random.Range(-ScoreManager.instance.arenaScale / 2, ScoreManager.instance.arenaScale / 2)), gameObject.transform.rotation);

                    break;
                case 2:
                    //make bullet come from angle based on time smoothly
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (ScoreManager.instance.totalTimer * 120)%360));

                    //spawn bullet straight through the middle
                    Instantiate(bullet, transform.right * -distance, transform.rotation);

                    break;
                case 3:
                    gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360.0f)));

                    Instantiate(bullet, (transform.right * -distance) + (transform.up * ScoreManager.instance.arenaScale / 2), gameObject.transform.rotation);
                    Instantiate(bullet, (transform.right * -distance) + (transform.up * ScoreManager.instance.arenaScale / 4), gameObject.transform.rotation);
                    Instantiate(bullet, (transform.right * -distance) + (transform.up * 0), gameObject.transform.rotation);
                    Instantiate(bullet, (transform.right * -distance) + (transform.up * -ScoreManager.instance.arenaScale / 2), gameObject.transform.rotation);
                    Instantiate(bullet, (transform.right * -distance) + (transform.up * -ScoreManager.instance.arenaScale / 4), gameObject.transform.rotation);

                    //small cooldown for sanity sake
                    duration = -5;
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
