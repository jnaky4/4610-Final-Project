using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(0, 2000, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
