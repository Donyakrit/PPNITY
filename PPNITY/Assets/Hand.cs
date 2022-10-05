using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static string Inhand;
    public static int Point;
    public string LocalInhand;

    // Start is called before the first frame update
    void Start()
    {
        Inhand = LocalInhand;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Inhand);
        Debug.ClearDeveloperConsole();
    }
}
