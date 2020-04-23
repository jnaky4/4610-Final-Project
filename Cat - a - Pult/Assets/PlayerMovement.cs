using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float verticalForce = 2000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // FixedUpdate is used for physics and performs better
    void FixedUpdate()
    {
        rb.AddForce(0, verticalForce * Time.deltaTime, 0);
        if (Input.GetKey("d"))
        {
            rb.AddForce(500 * Time.deltaTime, 0 , 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }
    }
}
