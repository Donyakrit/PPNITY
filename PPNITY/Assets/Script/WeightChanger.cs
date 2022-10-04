using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeightChanger : MonoBehaviour
{
    public TMP_Text WeightText;
    // Start is called before the first frame update
    void Start()
    {
        Backpack.MaxWeight = 8;
    }

    // Update is called once per frame
    void Update()
    {
        WeightText.text = Backpack.CurrenWeight.ToString() + " / " + Backpack.MaxWeight.ToString();
        if(Input.GetKeyDown(KeyCode.O))
        {
            Backpack.CurrenWeight++;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Backpack.CurrenWeight--;
        }
    }
}
