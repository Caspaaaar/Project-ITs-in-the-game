using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    private Vector3 movement;
    private float x;
    private float y;
    public float speed;
    public float floatiness;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x = 0;
        y = 0;
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            y += 1;
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            y += -1;
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            x += -1;
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            x += 1;
        }

        movement = new Vector3(x, y, 0f);
        movement = movement.normalized;
        movement = movement * speed * Time.deltaTime;

        gameObject.transform.position += movement;

    }
}
