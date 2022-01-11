using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
   
    void Awake()
    {
         Scene currentScene = SceneManager.GetActiveScene();

          if(FadeScript.instance.name == "GameScene")
         {
        //Stops playing intro audio in GameScene
           Destroy(this.gameObject);
         }
         else 
         {
         DontDestroyOnLoad(this.gameObject);
         }
    }
}

