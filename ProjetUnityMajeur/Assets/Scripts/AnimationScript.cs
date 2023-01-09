using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationScript : MonoBehaviour
{
    // public Light _light;
    public GameObject _lights;
    public SpotRGB _spotRGB_1;
    public SpotRGB _spotRGB_2;
    public float _intensityDefault;
    public float _intensityMultiplier;
    public float check_0;
    public float check_1;
    public float check_2;
    public float check_3;
    public float check_4;
    public float check_5;
    public float check_6;
    public float check_7;

    public float check_time;

    public Camera _camera;
    private Vector3 _posInitCamera;

    // Start is called before the first frame update
    void Start()
    {
        _posInitCamera = _camera.transform.position;
        // _spotRGB._intensity = _intensity;
    }

    public float intensity_spotRGB_bassefreq(float spectre)
    {
        float intensity;
        if (spectre <= 0.08f)
        {
            intensity = 0f;
        }
        else
        {
            intensity = _intensityMultiplier * (AudioPeer._freqBand[0] + _intensityDefault);
        }
        return intensity;
    }

    public void ZoomCamera(float spectre)
    {
        if (spectre <= 1.5f)
        {
            _camera.transform.position = _posInitCamera;
        }
        else
        {
            _camera.transform.position = _posInitCamera + new Vector3(0,0,spectre * 10);
        }
    }

    public void AnimHSV(SpotRGB spotRGB, float time)
    {
        float hue = time * 360;

        // Convertir la teinte, la saturation et la luminosité en valeurs RGB
        int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
        float f = hue / 60 - (float)Math.Floor(hue / 60);

        float value = 1;
        float saturation = 1;
        float v = value;
        float p = value * (1 - saturation);
        float q = value * (1 - f * saturation);
        float t = value * (1 - (1 - f) * saturation);

        float r, g, b;

        if (hi == 0)
        {
            r = v;
            g = t;
            b = p;
        }
        else if (hi == 1)
        {
            r = q;
            g = v;
            b = p;
        }
        else if (hi == 2)
        {
            r = p;
            g = v;
            b = t;
        }
        else if (hi == 3)
        {
            r = p;
            g = q;
            b = v;
        }
        else if (hi == 4)
        {
            r = t;
            g = p;
            b = v;
        }
        else
        {
            r = v;
            g = p;
            b = q;
        }
        spotRGB._intensity_R = _intensityMultiplier * (r + _intensityDefault);
        spotRGB._intensity_G = _intensityMultiplier * (g + _intensityDefault);
        spotRGB._intensity_B = _intensityMultiplier * (b + _intensityDefault);
        // Créer une couleur RGB à partir des valeurs calculées
        // Color color = Color.FromArgb(255, (int)(r * 255), (int)(g * 255), (int)(b * 255));

        // return color;
    }




    // Update is called once per frame
    void Update()
    {
        // check = _intensityMultiplier * (AudioPeer._freqBand[0] + 1);
        check_0 = AudioPeer._freqBand[0];
        check_1 = AudioPeer._freqBand[1];
        check_2 = AudioPeer._freqBand[2];
        check_3 = AudioPeer._freqBand[3];
        check_4 = AudioPeer._freqBand[4];
        check_5 = AudioPeer._freqBand[5];
        check_6 = AudioPeer._freqBand[6];
        check_7 = AudioPeer._freqBand[7];
        check_time = Time.time;

        // _spotRGB._intensity = _intensity * (AudioPeer._freqBand[0] + 1);

        foreach (Transform child in _lights.transform)
        {
            child.GetComponent<SpotRGB>()._intensity = intensity_spotRGB_bassefreq(AudioPeer._freqBand[0]);

            child.GetComponent<SpotRGB>().transform.Rotate(0, 0, AudioPeer._freqBand[6] * 10000 * Time.deltaTime);
        }
        
        ZoomCamera(AudioPeer._freqBand[1]);
        AnimHSV(_spotRGB_1, Time.time);
        AnimHSV(_spotRGB_2, Time.time + 0.5f);
    }
}
