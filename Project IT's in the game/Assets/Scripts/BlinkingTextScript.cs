using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingTextScript : MonoBehaviour
{

    public float onTime = 1f;
    public float offTime = 0.5f;

    void Start()
    {
        InvokeRepeating("ToggleOn", 0, onTime + offTime);
        InvokeRepeating("ToggleOff", onTime, offTime + onTime);
    }

    public void ToggleOn()
    {
        gameObject.SetActive(true);
    }

    public void ToggleOff()
    {
        gameObject.SetActive(false);
    }

}