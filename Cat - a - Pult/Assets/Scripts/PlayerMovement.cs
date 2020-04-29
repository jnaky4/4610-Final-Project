using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public bool flying = false;
    public bool bounceControl = false;
    public float jumpVelocity;
    public Rigidbody rb;
    public float verticalForce = 2000.0f;
    int count = 0;
    const float maxSpeed = 60f;
    public GameObject Cat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame



    // FixedUpdate is used for physics and performs better
    void FixedUpdate()
    {
        if(rb.position.y < 0)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.transform.position = new Vector3(90f, .5f, -60f);
        }
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (Cat.GetComponent<CatControl>() != null)
        {
            flying = Cat.GetComponent<CatControl>().flying;
        }

        if (Input.GetKey("d"))
        {
            if (!flying)
            {
                rb.AddForce(transform.right * 300 * Time.deltaTime, ForceMode.VelocityChange);
                //rb.AddForce(300 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey("a"))
        {
            if (!flying)
            {
                rb.AddForce(transform.right * -300 * Time.deltaTime, ForceMode.VelocityChange);
                //rb.AddForce(-300 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            
        }
        if (Input.GetKey("w"))
        {
            if (!flying)
            {
                rb.AddForce(transform.forward * 300 * Time.deltaTime, ForceMode.VelocityChange);
                //rb.AddForce(0, 0, 300 * Time.deltaTime, ForceMode.VelocityChange);
                //rb.AddForce(transform.forward * 300);
            }                    
        }
        if (Input.GetKey("s"))
        {
            if (!flying)
            {
                rb.AddForce(transform.forward * -300 * Time.deltaTime, ForceMode.VelocityChange);
                //rb.AddForce(0, 0, -300 * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
        if (Input.GetKey("q"))
        {
            if (!flying)
            {
                transform.Rotate(Vector3.up, -50.0f * Time.deltaTime);

            }
        }
        if (Input.GetKey("e"))
        {
            if (!flying)
            {

                transform.Rotate(Vector3.up, 50.0f * Time.deltaTime);

            }
        }

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
   
            rb.velocity = Vector3.zero;

        }



        //Debug.Log(rb.velocity.y);
        if (rb.velocity.y < .1 && rb.velocity.y > -.1)
        {
            //Debug.Log("landed");
            flying = false;
            if (rb.velocity.y == 0)
            {
                count = 1;
            }
            if (rb.velocity.y == 0 && count == 1)
            {

                bounceControl = false;
                count = 0;
            }
        }
        if(rb.velocity.y > .1 || rb.velocity.y < -.1)
        {
            //Debug.Log("flying");
            flying = true;

        }
    }
    
}
