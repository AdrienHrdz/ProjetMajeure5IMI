using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScenePhyllo : MonoBehaviour
{
    public float[] checksAudioPeer;
    public float checkTimeSeconds;
    public float _intensityDefault = 0.5f;
    public float _intensityMultiplier = 1f;
    public GameObject[] lights;
    public GameObject[] phylloTrails;

    // Start is called before the first frame update
    void Start()
    {
        checksAudioPeer = new float[8];
        
    }

    public float intensity_spotRGB_bassefreq(float spectre)
    {
        float intensity = 0f;
        if (spectre >= 0.08f)
            intensity = _intensityMultiplier * (AudioPeer._freqBand[0] + _intensityDefault);
        return intensity;
    }

    // Update is called once per frame
    void Update()
    {
        checksAudioPeer[0] = AudioPeer._freqBand[0];
        checksAudioPeer[1] = AudioPeer._freqBand[1];
        checksAudioPeer[2] = AudioPeer._freqBand[2];
        checksAudioPeer[3] = AudioPeer._freqBand[3];
        checksAudioPeer[4] = AudioPeer._freqBand[4];
        checksAudioPeer[5] = AudioPeer._freqBand[5];
        checksAudioPeer[6] = AudioPeer._freqBand[6];
        checksAudioPeer[7] = AudioPeer._freqBand[7];
        checkTimeSeconds = Mathf.Round(Time.time);

        foreach (GameObject go in lights)
        {
            go.GetComponent<SpotRGB>()._intensity = intensity_spotRGB_bassefreq(checksAudioPeer[0]);
            go.GetComponent<SpotRGB>().transform.Rotate(0,0,checksAudioPeer[6]*10000*Time.deltaTime);
        }
        foreach (GameObject go in phylloTrails)
        {
            if (AudioPeer._freqBand[0] <= 0.2f)
                go.SetActive(true);
            else
                go.SetActive(false);
        }
    }
}
