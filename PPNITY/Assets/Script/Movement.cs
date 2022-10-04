using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float turnspeed = 10f;
    public float jumppower = 10f;
    public bool OnGround = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(x * speed, 0f, z * speed);
        Animator animator = GetComponent<Animator>();
        if (x == 0f && z == 0f)
        {
            animator.SetBool("Is_Walk", false);
        }
        else
        {
            float degree = 90 - (Mathf.Atan2(z, x) * 180 / Mathf.PI);
            // Change the direction of the player
            Quaternion rotation1 = transform.rotation;
            Quaternion rotation2 = Quaternion.Euler(0f, degree, 0f);
            transform.rotation
            = Quaternion.RotateTowards(rotation1, rotation2, turnspeed);
            animator.SetBool("Is_Walk", true);
        }
    }    
}