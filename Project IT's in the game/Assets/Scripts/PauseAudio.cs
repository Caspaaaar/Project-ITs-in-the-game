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
          gameObject.GetComponent<AudioSource>().Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || PauseScript.GameIsPaused == false)
        {   
        gameObject.GetComponent<AudioSource>().UnPause();
        }
        }//input

    }//update

