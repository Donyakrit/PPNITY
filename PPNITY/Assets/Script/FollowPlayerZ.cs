using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerZ : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    Vector3 offsetz;
    float x;
    float y;

    private void Start()
    {
        offset = GetComponent<Transform>().position - target.position;
        x = GetComponent<Transform>().position.x;
        y = GetComponent<Transform>().position.y;
    }

    private void Update()
    {
        GetComponent<Transform>().position = new Vector3(x, y, target.position.z + offset.z);
    }
}
