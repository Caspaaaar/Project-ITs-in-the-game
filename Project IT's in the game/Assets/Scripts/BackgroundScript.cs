using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    private float duration;
    public float distance;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime * speed;

        duration %= distance*2;

        transform.position = transform.rotation * ((Vector3.right * (duration - distance)) + Vector3.forward);


    }
}
