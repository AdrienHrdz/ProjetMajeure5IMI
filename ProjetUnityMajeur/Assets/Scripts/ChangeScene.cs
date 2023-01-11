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
        Apmlitude = AudioPeer._bandBuffer[0];
        if (timeElapsed > delayBeforeLoading)
        {
            if (AudioPeer._bandBuffer[0] > 0.5f)
            {
            SceneManager.LoadScene(sceneNameToLoad);
            DontDestroyOnLoad(this._audioPeer);
            }

        }
    }
}
