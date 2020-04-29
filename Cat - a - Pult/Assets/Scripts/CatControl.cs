using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cat;
    public GameObject catapult;
    public bool flying = false;
    public bool bounceControl = false;
    public float jumpVelocity;
    public Rigidbody rb;
    public float verticalForce = 1000.0f;
    public float bounceForce = 1200.0f;
    public float forwardForce = 4.0f;
    int count = 0;
    const float maxSpeed = 60f;

    
    public Vector3 restartPos;
    private bool isReset = true;
    private Quaternion originalRotationValue;




    void Start()
    {
        rb = cat.AddComponent<Rigidbody>();
        rb.mass = 3000;

        rb.isKinematic = true;
        rb.detectCollisions = false;
        restartPos = transform.localPosition;
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        
        originalRotationValue = transform.rotation;

        

    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!flying)
            {
                if (forwardForce > 0)
                {
                    forwardForce -= 1;
                }
                    
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!flying)
            {
                if(forwardForce < 15)
                {
                    forwardForce += 1;
                }
                
            }
        }
       
    }


    void FixedUpdate()
    {

        if (Input.GetKey("space"))


        {
            rb.isKinematic = false;
            rb.detectCollisions = true;

            if (!flying)
            {
                rb.AddForce(0, verticalForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                rb.AddForce(transform.forward * forwardForce, ForceMode.VelocityChange);
                flying = true;
                isReset = false;
            }
            
        }
        if (Input.GetKey("d"))
        {
            if (!flying || bounceControl)
            {
                rb.AddForce(transform.right * 100 * Time.deltaTime, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey("a"))
        {
            if (!flying || bounceControl)
            {

                rb.AddForce(transform.right * -100 * Time.deltaTime, ForceMode.VelocityChange);
            }


        }
        if (Input.GetKey("w"))
        {
            if (!flying || bounceControl)
            {

                rb.AddForce(transform.forward * 100 * Time.deltaTime, ForceMode.VelocityChange);
                //rb.AddForce(transform.forward * 300);
            }
        }
        if (Input.GetKey("s"))
        {
            if (!flying || bounceControl)
            {

                rb.AddForce(transform.forward * -100 * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
        if (Input.GetKey("q"))
        {
            if (flying)
            {
                transform.Rotate(Vector3.up, -100.0f * Time.deltaTime);

            }
        }
        if (Input.GetKey("e"))
        {
            if (flying)
            {

                transform.Rotate(Vector3.up, 100.0f * Time.deltaTime);

            }
        }

            if (rb.velocity.y < .1 && rb.velocity.y > -.1 && rb.velocity.x < .1 && rb.velocity.x > -.1 && rb.velocity.z < .1 && rb.velocity.z > -.1)
        {
            //Debug.Log("landed");

            if (rb.velocity.y == 0)
            {
                count = 1;
            }
            if (rb.velocity.y == 0 && count == 1)
            {

                bounceControl = false;
                flying = false;
                if(transform.localPosition != restartPos)
                {
                    Debug.Log("Stopped Flying");
                    reset();
                }
                count = 0;
            }
        }

        if (rb.velocity.y > .1 || rb.velocity.y < -.1)
        {
            
            flying = true;
            
        }
        if(!isReset && !flying)
        {
            //Debug.Log("Stopped Flying");
        }
        //Debug.Log(transform.position.y);
        if(transform.position.y < -10)
        {
            Debug.Log("Below World");
            reset();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bounce")
        {
            Debug.Log("Bounce Control");
            bounceControl = true;
            rb.AddForce(0, bounceForce * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        if (collision.collider.tag == "Side Bounce")
        {
            var relativePosition = (collision.transform.position - transform.position).normalized;






            bounceControl = true;


        }
    }
    private void reset()
    {
        Debug.Log("Reset");
        rb.isKinematic = true;
        rb.detectCollisions = false;
        transform.localPosition = restartPos;
        //transform.rotation = originalRotationValue;
        transform.rotation = catapult.transform.rotation;
        isReset = true;

    }


}

    

