using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour
{
    public GameObject coin;
    public float fireRate;
    public float maxDistance;
    public float minDistance;
    private float duration;
    


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        duration += (Time.deltaTime);

        if(duration > fireRate)
        {
            duration = 0;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360.0f)));


            Instantiate(coin, (transform.right * Random.Range(minDistance, maxDistance)), gameObject.transform.rotation);
        }
    }
}
