using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelScript : MonoBehaviour
{

    //https://www.youtube.com/watch?v=wHPo3vmoNi8

    public RenderTexture RenderTexture;
    public int pixelation;

    // Start is called before the first frame update
    void Start()
    {
        RenderTexture.width = Screen.width / pixelation;
        RenderTexture.height = Screen.height / pixelation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
