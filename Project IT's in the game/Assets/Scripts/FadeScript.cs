using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    public Animator animator;
    public static FadeScript instance;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void LoadLevel(string sceneName)
    {
        StartCoroutine(LoadWithFade(sceneName));
    }

    IEnumerator LoadWithFade(string sceneName)
    {
        animator.SetTrigger("Fade");

        yield return new WaitForSeconds(.75f);

        SceneManager.LoadScene(sceneName);
    }
}
