﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float speed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        
        gameObject.transform.Translate(direction.normalized * Time.deltaTime * speed);

    }

}