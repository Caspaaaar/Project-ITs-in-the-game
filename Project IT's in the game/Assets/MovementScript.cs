using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    private CharacterController Controller;
    private Vector3 Movement;
    

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement = new Vector3(1, 1, 0);
        Controller.Move(Movement);
    }
}
