using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    public float Xparallax;
    public float Yparallax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.activeSelf)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x / Xparallax, player.transform.position.y / Yparallax, gameObject.transform.position.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(0, -1, gameObject.transform.position.z);
            Camera.main.orthographicSize = 15;
        }
    }
}
