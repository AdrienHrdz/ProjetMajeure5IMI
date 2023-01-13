using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string sceneNameToLoad;
    private float timeElapsed;

    public AudioPeer _audioPeer;

    public float Apmlitude;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        Apmlitude = AudioPeer._AmplitudeBuffer;
        if (timeElapsed > delayBeforeLoading)
        {
            
            
            SceneManager.LoadScene(sceneNameToLoad);
            DontDestroyOnLoad(this._audioPeer);
            

        }
    }
}
