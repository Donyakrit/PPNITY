using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverHeadIcon : MonoBehaviour
{
    public GameObject Dirt;
    public GameObject Sand;
    public GameObject Clay;
    public GameObject WaterCan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hand.Inhand == "Dirt")
        {
            Dirt.SetActive(true);
        }
        else
        {
            Dirt.SetActive(false);
            if (Hand.Inhand == "Sand")
            {
                Sand.SetActive(true);
            }
            else
            {
                Sand.SetActive(false);
                if (Hand.Inhand == "Clay")
                {
                    Clay.SetActive(true);
                }
                else
                {
                    Clay.SetActive(false);
                    if (Hand.Inhand == "WaterCan")
                    {
                        WaterCan.SetActive(true);
                    }
                    else
                    {
                        WaterCan.SetActive(false);
                    }
                }
            }
        }
    }
}
