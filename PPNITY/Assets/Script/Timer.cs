using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    float currentTime;
    public float SetTime;
    public static int ReminingTime;
    // Start is called before the first frame update
    void Start()
    {
        ReminingTime = (int)SetTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        ReminingTime = ((int)(SetTime - currentTime + 5));

        if(ReminingTime < 0)
        {
            ReminingTime = 0;
        }

        TimerText.text = ReminingTime.ToString();

        if(SetTime - currentTime + 5 > SetTime)
        {
            TimerText.text = SetTime.ToString();
        }
    }
}
