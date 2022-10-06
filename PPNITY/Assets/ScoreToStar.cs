using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreToStar : MonoBehaviour
{
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    // Start is called before the first frame update
    void Start()
    {
        Star1.SetActive(false);
        Star2.SetActive(false);
        Star3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Hand.Point == 30)
        {
            Star3.SetActive(true);
        }
        else
        {
            if (Hand.Point >= 25)
            {
                Star2.SetActive(true);
            }
            else
            {
                if (Hand.Point >= 15)
                {
                    Star1.SetActive(true);
                }
                else
                {

                }
            }
        }
    }
}
