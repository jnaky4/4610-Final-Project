using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour
{
    public GameObject cameraObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){Cursor.lockState = CursorLockMode.Locked;}
        if (Input.GetKeyDown(KeyCode.Escape)){Cursor.lockState = CursorLockMode.None;}

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Vector3 eulerangles = transform.eulerAngles;
            eulerangles.y += Input.GetAxis("Mouse X");
            transform.eulerAngles = eulerangles;

            eulerangles = cameraObject.transform.eulerAngles;
            eulerangles.x -= Input.GetAxis("Mouse Y");
            transform.eulerAngles = eulerangles;

        }

    }
}
