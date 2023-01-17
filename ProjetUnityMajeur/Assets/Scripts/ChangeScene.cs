using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random=System.Random;


public class ChangeScene : MonoBehaviour
{
    public enum SceneName {
                SceneKoch, 
                SceneAdrien2, 
                SceneKochTrail, 
                SceneAtomVisu};

    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    // private string sceneNameToLoad;
    private float timeElapsed;

    public AudioPeer _audioPeer;

    public float Apmlitude;

    Random rand = new Random();

    private void Update()
    {
        if (Input.GetKey("escape") || Input.GetKey("space"))
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        timeElapsed += Time.deltaTime;
        Apmlitude = AudioPeer._AmplitudeBuffer;

        
        if (timeElapsed > delayBeforeLoading)
        {
            if (SceneManager.GetActiveScene().name == "ScenePrincipal")
            {
                int SceneIndex = rand.Next(1, 5);
                SceneManager.LoadScene(SceneIndex);
                DontDestroyOnLoad(this._audioPeer);
            } 
            else
            {
                if (timeElapsed > delayBeforeLoading)
                {
                    if (AudioPeer._AmplitudeBuffer < 0.2f || timeElapsed > delayBeforeLoading + 25f)
                    {
                        int SceneIndex = rand.Next(1, 5);
                        SceneManager.LoadScene(SceneIndex);
                        
                        DontDestroyOnLoad(this._audioPeer);
                    }
                }
            }
        }
    }
}
