using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnerScript : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate;
    public float maxDistance;
    public float minDistance;
    public float maxOffset;
    public float increaseTempo;
    private float duration;
    public float totalDuration;
    


    // Start is called before the first frame update
    void Start()
    {
        maxOffset = Mathf.Sqrt(maxOffset);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      totalDuration += Time.deltaTime;
        duration += (Time.deltaTime * (totalDuration/increaseTempo));

        if(duration > fireRate)
        {
            duration = 0;
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360.0f)));


            Instantiate(bullet, (transform.right * Random.Range(minDistance, maxDistance)), gameObject.transform.rotation);
        }
    }
}
