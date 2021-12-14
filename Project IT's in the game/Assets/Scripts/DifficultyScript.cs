using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void difficultyNoob()
    {
        PlayerPrefs.SetInt("startingHealth", 5);
    }
    public void difficultyNormal()
    {
        PlayerPrefs.SetInt("startingHealth", 3);
    }
    public void difficultyHard()
    {
        PlayerPrefs.SetInt("startingHealth", 1);
    }
}
