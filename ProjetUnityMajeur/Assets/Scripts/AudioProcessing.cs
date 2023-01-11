using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioProcessing : MonoBehaviour
{
    AudioSource _audioSource;
    // public GameObject AudioPeer;
    public int sr;
    public float[] audioData;
    public float[] filteredAudio;
    public int BPM;
    public int nbchannles;

    // Start is called before the first frame update
    void Start()
    {   
        // load the data from the audioclip
        // audioClip = AudioPeer.GetComponent<AudioSource>().AudioClip;
        // sr = audioClip.frequency;
        // audioData = new float[audioClip.samples];
        // audioClip.GetData(audioData, 0);
        // nbchannles = audioClip.channels;

        // Destroy(audioClip);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
