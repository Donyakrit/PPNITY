using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneName;

    public void sceneload()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneName);
    }
}
