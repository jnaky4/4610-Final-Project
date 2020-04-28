using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeView : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -50 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 50 * Time.deltaTime, 0);
        }


    }
}
