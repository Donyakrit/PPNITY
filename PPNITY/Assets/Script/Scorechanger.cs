using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorechanger : MonoBehaviour
{
    public TMP_Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Hand.Point.ToString();
    }
}
