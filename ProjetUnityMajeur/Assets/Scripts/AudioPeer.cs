using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]


public class AudioPeer : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    //avoir value entre 0 et 1 (plus pratique à utiliser)
    float[] _freqBandHighest = new float[8]; 
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

    //permet d'obtenir l'amplitude moyenne de tous le signal
    public static float _Amplitude;
    public static float _AmplitudeBuffer;
    float _AmplitudeHighest;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }

    void GetAmplitude() //récupère l'amplitude moyenne de tout le signal
    {
        float _CurrentAmplitude = 0;
        float _CurrentAmplitudeBuffer = 0;
        for (int i = 0; i < 8; i++)
        {
            _CurrentAmplitude += _audioBand [i];
            _CurrentAmplitudeBuffer += _audioBandBuffer [i];
        }
        if (_CurrentAmplitude > _AmplitudeHighest) 
        {
            _AmplitudeHighest = _CurrentAmplitude;
        }
        _Amplitude = _CurrentAmplitude / _AmplitudeHighest;
        _AmplitudeBuffer = _CurrentAmplitudeBuffer / _AmplitudeHighest;
    }

    void CreateAudioBands() //normalise nos bande entre 0 et 1
    {
        for (int i = 0; i < 8; i++)
        {
            if (_freqBand[i] > _freqBandHighest [i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
        }
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);

    }


    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if (_freqBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            if (_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease [g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()
    {
        /*
         * 22050 / 512 = 43 Hz pa �chantillon
         * 
         * on peut diviser notre spectre audio en 7 cat�gorie
         * 20-60 hz
         * 60-250 hz
         * 250-500
         * 500-2000
         * 2000-4000
         * 4000-6000
         * 6000-20000
         * 
         * on veut placer le bon nombre d'�chantillons dans chaque cat�gorie
         * 0 - 2 = 86 hz 
         * 1 - 4 = 172 hz 87->258
         * 2 - 8 = 344 hz 259->602
         * 3 - 16 = 688 hz 603->1290
         * 4 - 32 = 1376 hz 1291->2666
         * 5 - 64 = 2752 hz 2667->5418
         * 6 - 128 = 5504 hz 5419->10922
         * 7 - 256 = 11008 hz 10923->21930
         */
        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2; //pour avoir 2, puis 4 puis 8 ect
            if (i == 7)
            {
                sampleCount += 2; //pour prendre en compte les 2 ehcnatillons restant
            }
            for (int j =0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;

            _freqBand[i] = average * 10;
        }
    }
}