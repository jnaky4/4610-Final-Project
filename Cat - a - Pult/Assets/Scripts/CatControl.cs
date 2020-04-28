using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cat;
    public bool flying = false;
    public bool bounceControl = false;
    public float jumpVelocity;
    public Rigidbody rb;
    public float verticalForce = 2000.0f;
    int count = 0;
    const float maxSpeed = 60f;
    void Start()
    {
        rb = cat.AddComponent<Rigidbody>();
        rb.mass = 3000;
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (!flying)
            {
                verticalForce -= 200;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!flying)
            {
                verticalForce += 200;
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
                flying = true;
            }

        }
        if (Input.GetKey("d"))
        {
            if (!flying || bounceControl)
            {
                rb.AddForce(300 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }

        if (Input.GetKey("a"))
        {
            if (!flying || bounceControl)
            {

                rb.AddForce(-300 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }


        }
        if (Input.GetKey("w"))
        {
            if (!flying || bounceControl)
            {

                rb.AddForce(0, 0, 300 * Time.deltaTime, ForceMode.VelocityChange);
                //rb.AddForce(transform.forward * 300);
            }
        }
        if (Input.GetKey("s"))
        {
            if (!flying || bounceControl)
            {

                rb.AddForce(0, 0, -300 * Time.deltaTime, ForceMode.VelocityChange);
            }
        }

        if (rb.velocity.y < .1 && rb.velocity.y > -.1)
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
                count = 0;
            }
        }
        if (rb.velocity.y > .1 || rb.velocity.y < -.1)
        {
            //Debug.Log("flying");
            flying = true;

        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {

        //Debug.Log(collision.collider.tag);

        if (collision.collider.tag == "LevelWon")
        {
            Debug.Log("Level Complete");


        }




        if (collision.collider.tag == "Bounce")
        {
            bounceControl = true;
            rb.AddForce(0, verticalForce * 2 * Time.deltaTime, 0, ForceMode.VelocityChange);
        }
        if (collision.collider.tag == "Side Bounce")
        {
            var relativePosition = (collision.transform.position - transform.position).normalized;
            if (relativePosition.x > 0)
            {
                Debug.Log("right");
            }
            else
            {
                Debug.Log("left");

            }

            if (relativePosition.y > 0)
            {
                Debug.Log("above");
            }
            else
            {
                Debug.Log("below");
            }

            if (relativePosition.z > 0)
            {
                Debug.Log("front");
            }
            else
            {
                Debug.Log("behind");
            }


            //Vector3 direction = (collision.transform.position - transform.position).normalized;

            //if(Vector3.Dot (transform.forward, direction) > 0)
            //{
            //    Debug.Log("back");
            //}
            //if (Vector3.Dot(transform.forward, direction) < 0)
            //{
            //    Debug.Log("front");
            //}
            //if (Vector3.Dot(transform.forward, direction) == 0)
            //{
            //    Debug.Log("side");
            //}



            //(transform.position - collision.collider.gameObject.transform.position).normalized;


            bounceControl = true;
            //rb.AddForce(verticalForce * 2 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        }
    }
}

    

