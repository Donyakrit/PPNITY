using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private IEnumerator coroutine;

    public string SceneName;
    public GameObject LoadingScreen;
    public GameObject MainScreen;

    public void sceneload()
    {
        coroutine = Wait(2.0f);
        StartCoroutine(coroutine);
    }

    public void StartTheGame()
    {
        LoadingScreen.SetActive(true);
        MainScreen.SetActive(false);
        coroutine = Wait(2.0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator Wait(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene(SceneName);
    }
}
