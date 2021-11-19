using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject == player)
        {
            player.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
