using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed;
    public float life;
    private float duration = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;

        gameObject.transform.position += transform.right * speed * Time.deltaTime;

        if(duration > life)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
