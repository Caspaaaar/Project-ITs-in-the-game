using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirkelScript : MonoBehaviour
{
    public float shrinkRate;
    public float maxGrootte;
    public float minGrootte;
    public float stepTime;

    // Start is called before the first frame update
    void Start()
    {
        stepTime = stepTime * shrinkRate;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreManager.instance.arenaScale = Mathf.Clamp(stepTime + maxGrootte - (ScoreManager.instance.totalTimer * shrinkRate), minGrootte, maxGrootte);
        transform.localScale = new Vector3(ScoreManager.instance.arenaScale, ScoreManager.instance.arenaScale, 1);
    }
}
