using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KonamiScript : MonoBehaviour
{

    public DamageScript damageScript;

    public string konamiCode;
    public string otherCode;
    private string typedCode;

    private float duration;
    public float maxInterval;
    private string temp;

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
                damageScript.health = 30;
                damageScript.UpdateHud();
            }

            if (typedCode.Equals(otherCode))
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
