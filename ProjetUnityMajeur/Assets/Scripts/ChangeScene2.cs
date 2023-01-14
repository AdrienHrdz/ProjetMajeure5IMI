using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene2 : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string sceneNameToLoad;
    private float timeElapsed;

    public AudioPeer _audioPeer;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading)
        {
            if (AudioPeer._AmplitudeBuffer < 0.2f)
            {
                SceneManager.LoadScene(sceneNameToLoad);
                DontDestroyOnLoad(this._audioPeer);
            }
        }
    }
}