using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    public static MusicPlay musicplay;
    public AudioSource backgroundMusic;
    // Start is called before the first frame update
    void Awake()
    {
        if (musicplay == null)
        {
            DontDestroyOnLoad(gameObject);
            musicplay = this;
        }
        else if (musicplay != this)
        {
            Destroy(gameObject);
        }
    }
    public void StartBackgroundMusic(bool aRestart)
    {
        if (!backgroundMusic.isPlaying || aRestart)
            backgroundMusic.Play();
    }
    public void StartBackgroundMusic()
    {
        backgroundMusic.Stop();
    }
}
