using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDream : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        offset = GetComponent<Transform>().position - target.position;
        y = GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = new Vector3(target.position.x + offset.x, y, target.position.z + offset.z);
    }
}
