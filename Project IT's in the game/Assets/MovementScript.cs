using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    private CharacterController Controller;
    private Vector3 Movement;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Vertical") + " and " + Input.GetAxis("Horizontal"));
        Movement = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0);
        Controller.Move(Movement * Time.deltaTime);
    }
}
