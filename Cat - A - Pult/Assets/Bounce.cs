using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody rb;




    public float radius = 0.0f;
    public float power = 2000.0f;
    public float upwardsModifier = 0.0f;

    Vector3 epicentro;
    // Start is called before the first frame update
    void Start()
    {

        Vector3 explosionPos = transform.position;
        epicentro = explosionPos;



    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
