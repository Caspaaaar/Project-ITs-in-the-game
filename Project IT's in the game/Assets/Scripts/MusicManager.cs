using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // add the callback method when scene loads
        Debug.Log("yes");
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "GameScene")
        {
            // Stops playing music in level 1 scene
            Destroy(gameObject);

            Debug.Log("no");
        }

    }
}

