using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScript : MonoBehaviour
{

    public GameObject player;
    private DamageScript damageScript;

    // Start is called before the first frame update
    void Start()
    {
        damageScript = player.GetComponent<DamageScript>();
    }

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            damageScript.fall();
        }
    }
}
