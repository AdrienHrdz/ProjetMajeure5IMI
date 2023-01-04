using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotRGB : MonoBehaviour
{
    public Light _R;
    public Light _G;
    public Light _B;

    public float _range;
    public float _intensity;
    public float _intensity_R = 1f;
    public float _intensity_G = 1f;
    public float _intensity_B = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        _R.intensity = _intensity * _intensity_R;
        _G.intensity = _intensity * _intensity_G;
        _B.intensity = _intensity * _intensity_B;
    }

    // Update is called once per frame
    void Update()
    {
        _R.intensity = _intensity * _intensity_R;
        _G.intensity = _intensity * _intensity_G;
        _B.intensity = _intensity * _intensity_B;
    }
}
