using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        try
        {
            gameObject.transform.position = new Vector3(player.transform.position.x / 2, player.transform.position.y / 2, gameObject.transform.position.z);
        }
        catch
        {
            gameObject.transform.position = new Vector3(0, 0, gameObject.transform.position.z);
            Camera.main.orthographicSize = 15;
        }
    }
}
