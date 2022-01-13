using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
   
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name != "GameScene")
        {
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Stops playing music in level 1 scene
            Destroy(gameObject);
        }

    }
}

