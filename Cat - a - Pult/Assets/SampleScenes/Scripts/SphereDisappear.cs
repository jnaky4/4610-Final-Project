using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDisappear : MonoBehaviour
{
    public float minSpeed = 3;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minSpeed)
        {
            Destroy(gameObject);
        }


    }
}