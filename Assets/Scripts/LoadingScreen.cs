using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        yield return null;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            // Update your loading screen UI to display loading progress
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // The progress value is between 0 and 0.9
            Debug.Log("Loading progress: " + (progress * 100) + "%");

            // If the loading has completed, activate the main scene
            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
