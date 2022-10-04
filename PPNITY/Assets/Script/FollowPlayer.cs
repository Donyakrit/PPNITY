using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    Vector3 offsetz;
    float z;

    private void Start()
    {
        offset = GetComponent<Transform>().position - target.position;
        z = GetComponent<Transform>().position.z;
    }

    private void Update()
    {
        GetComponent<Transform>().position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, z);
    }
}
