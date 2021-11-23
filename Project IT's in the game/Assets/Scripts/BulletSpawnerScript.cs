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
    private float totalDuration;
    public Text txt;

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


            Instantiate(bullet, (transform.right * -distance) + (transform.up * Random.Range(-maxOffset, maxOffset) * Random.Range(-maxOffset, maxOffset)), gameObject.transform.rotation);
        }


        txt.text = Mathf.RoundToInt(totalDuration).ToString();
    }
}
