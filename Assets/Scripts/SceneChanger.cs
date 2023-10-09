using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private string sceneMain = "MainScene";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneMain);
        }

    }
    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    
}
