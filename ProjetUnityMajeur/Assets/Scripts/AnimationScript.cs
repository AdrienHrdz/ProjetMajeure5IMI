using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    // public Light _light;
    public GameObject _lights;
    // public SpotRGB _spotRGB;
    public float _intensity = 100f;
    public float check;
    // Start is called before the first frame update
    void Start()
    {
        // _spotRGB._intensity = _intensity;
    }

    // Update is called once per frame
    void Update()
    {
        check = _intensity * (AudioPeer._freqBand[0] + 1);
        // _spotRGB._intensity = _intensity * (AudioPeer._freqBand[0] + 1);

        foreach (Transform child in _lights.transform)
        {
            child.GetComponent<SpotRGB>()._intensity = _intensity * (AudioPeer._freqBand[0] + 1);
        }
       
    }
}
