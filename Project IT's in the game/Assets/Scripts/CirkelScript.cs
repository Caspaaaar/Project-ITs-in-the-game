using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirkelScript : MonoBehaviour
{
    public BulletSpawnerScript BulletSpawnerScript;
    public float shrinkRate;
    public float maxGrootte;
    public float minGrootte;
    public float stepTime;
    private float currentScale;

    // Start is called before the first frame update
    void Start()
    {
        stepTime = stepTime * shrinkRate;
    }

    // Update is called once per frame
    void Update()
    {
        currentScale = Mathf.Clamp(stepTime + maxGrootte - (ScoreManager.instance.TotalTimer * shrinkRate), minGrootte, maxGrootte);
        transform.localScale = new Vector3(currentScale, currentScale, 0);
    }
}
