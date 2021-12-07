using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{
    private GameObject item;
    public float fireRate;
    public float maxDistance;
    public float minDistance;
    private float duration;
    public GameObject[] items;
    public float[] chances;
    private float chanceSum;
    


    // Start is called before the first frame update
    void Start()
    {
        chanceSum = 0;
        foreach (int item in chances)
        {
            chanceSum += item;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        duration += (Time.deltaTime);

        if(duration > fireRate)
        {
            //decide what item gets dropped
            float result = Random.value * chanceSum;
            float temp = 0;
            for (int i = 0; i < chances.Length; i++)
            {
                temp += chances[i];

                if(result < temp)
                {
                    
                    item = items[i];
                    break;
                }
            }



            //spawn item
            duration = 0;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360.0f)));

            Instantiate(item, (transform.right * Random.Range((minDistance * ScoreManager.instance.arenaScale * 0.5f), (maxDistance * ScoreManager.instance.arenaScale * 0.5f))), Quaternion.Euler(0,0,0));
        }
    }
}
