using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    private float duration;
    public float distance;
    private Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;

        duration %= distance*2;

        transform.position = transform.rotation * (Vector3.right * (duration - distance));


    }
}
