using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://www.youtube.com/watch?v=JivuXdrIHK0
public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ScoreManager.instance.health > 0)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

   void OnMouseDown()
    {
        
    }
    public void Resume()
    {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false; 
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Resume();

        //SceneManager.LoadScene("MainMenu");
        FadeScript.instance.LoadLevel("MainMenu");

    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");

        PlayerPrefs.Save();

        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
        Resume();
    }
}
