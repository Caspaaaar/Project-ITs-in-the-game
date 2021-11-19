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
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        movement = new Vector3(x, y, 0f);
        movement = movement * Mathf.Pow(movement.magnitude, floatiness);
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }
        movement *= speed;
        gameObject.transform.position += movement;
    }
}
