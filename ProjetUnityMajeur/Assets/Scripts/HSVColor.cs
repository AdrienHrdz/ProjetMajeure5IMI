using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSVColor : MonoBehaviour
{
    
    public static Color TimeToHSV(float time)
    {
        float h = (time / 360f)%1f;
        float s = 1f;
        float v = 1f;
        return Color.HSVToRGB(h, s, v);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
