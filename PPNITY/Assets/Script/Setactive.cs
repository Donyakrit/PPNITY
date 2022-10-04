using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setactive : MonoBehaviour
{
    public GameObject Object;

    public void SetActive()
    {
        Object.SetActive(true);
    }

    public void SetNonActive()
    {
        Object.SetActive(false);
    }
}
