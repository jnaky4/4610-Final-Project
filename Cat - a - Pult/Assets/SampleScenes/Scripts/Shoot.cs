using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public float speed = 5;
    public AudioSource cannon;
    public AudioSource catScream;

    public List<Sphere> sperer;

	// Use this for initialization
	void Start () {
        Debug.Log("--Hello Unity!");

        //GameObject.Instantiate(bullet,transform.position,transform.rotation);
	}


	// Update is called once per frame
	void Update () {
        //Debug.Log("--Hello Unity! Update");

        if ( Input.GetMouseButtonDown(0) )
        {
            GameObject b = GameObject.Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody rgd = b.GetComponent<Rigidbody>();
            rgd.velocity = transform.forward * speed;
            cannon.Play();
            catScream.Play();
            Destroy(b,3f);
        }
        
    }

}
