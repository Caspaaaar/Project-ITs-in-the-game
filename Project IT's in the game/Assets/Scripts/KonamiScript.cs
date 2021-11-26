using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KonamiScript : MonoBehaviour
{

    public DamageScript damageScript;

    public string konamiCode;
    public string resetCode;
    private string typedCode;

    private float duration;
    public float maxInterval;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;


        if (Input.anyKeyDown)
        {
            typedCode += Input.inputString;

            duration = 0;


            if (typedCode.Equals(konamiCode))
            {
                ScoreManager.instance.health = 30;
                damageScript.cheats = true;
            }

            if (typedCode.Equals(resetCode))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }



        if (duration > maxInterval)
        {
            typedCode = "";
        }
    }

    
}
