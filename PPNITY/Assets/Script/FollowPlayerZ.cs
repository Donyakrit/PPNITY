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
    float z;

    private void Start()
    {
        offset = GetComponent<Transform>().position - target.position;
        x = GetComponent<Transform>().position.x;
        y = GetComponent<Transform>().position.y;
    }

    private void Update()
    {
        z = Mathf.Clamp(target.position.z + offset.z , -15.4f , 100f);
        GetComponent<Transform>().position = new Vector3(x, y, z);
    }
}
