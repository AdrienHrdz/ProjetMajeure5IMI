using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoad : MonoBehaviour
{
    public bool loadLevel;
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (loadLevel == true)
        {
            StartCoroutine(LoadLevelAsync());
        }
    }

    private IEnumerator LoadLevelAsync()
    {
        var progress = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);

        while (!progress.isDone)
        {
            yield return null;
        }
        Debug.Log("Level Loaded");
    }
}
