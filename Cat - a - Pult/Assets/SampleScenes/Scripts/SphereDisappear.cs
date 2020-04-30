using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereDisappear : MonoBehaviour
{
    public float minSpeed = 3;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minSpeed)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(1); 
        }


    }
}