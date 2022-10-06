using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoScene : MonoBehaviour
{
    public float currentTime;
    public string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 76)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}
