using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool flying = false;
    public bool bounceControl = false;
    public float jumpVelocity;
    public Rigidbody rb;
    public float verticalForce = 2000.0f;
    int count = 0;
    const float maxSpeed = 60f;


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
            }                    
        }
        if (Input.GetKey("s"))
        {
            if (!flying || bounceControl)
            {

            rb.AddForce(0, 0, -300 * Time.deltaTime, ForceMode.VelocityChange);
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

        if (Input.GetKey("space"))
        {
            //Debug.Log(rb.velocity.y);

            if (!flying)
            {
            rb.AddForce(0, verticalForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            flying = true;
            }

        }
        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            

            if (!flying)
            {
                rb.velocity = Vector3.zero;
            }

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
    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log(collision.collider.tag);
        

        if (collision.collider.tag == "LevelWon")
        {
            Debug.Log("Level Complete");
            SceneManager.LoadScene(2);

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
