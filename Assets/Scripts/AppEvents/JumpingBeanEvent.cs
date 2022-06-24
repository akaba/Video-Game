using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBeanEvent : MonoBehaviour
{

    //public float speed = 0;
    public float froceXmax = 4;
    public float froceXmin =-4;
    public float froceYmax = 7;
    private Rigidbody rb;
    public bool IsGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsGrounded = true;
    }


    void FixedUpdate()
    {
        if (IsGrounded)
        {

            //Vector3 movement = new Vector3(0.0f, 30f, 0.0f);
            //rb.AddForce(movement * speed);
            rb.velocity = new Vector3(Random.Range(froceXmin, froceXmax), Random.Range(3, froceYmax), 0);
            IsGrounded = false;
        }

    }

    //This is a physics callback
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "ground")
        {
            IsGrounded = true;
        }

    }



}
