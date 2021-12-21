using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    //Press any key to continue
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            FadeScript.instance.LoadLevel("MainMenu");
        }
    }
}
