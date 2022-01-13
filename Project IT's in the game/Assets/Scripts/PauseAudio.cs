using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //MusicManager.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                Camera.main.GetComponent<AudioSource>().Pause();
            }
            else
            {
                Time.timeScale = 1;
                Camera.main.GetComponent<AudioSource>().UnPause();
            }
        }//input

    }//update
}
