
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    public Transform catapult;
    public GameObject Cat;
    public Camera FollowCamera;
    public Camera CatapultCamera;
    
    //public Vector3 catapultOffset;
    public Vector3 catOffset;
    public Vector3 catapultOffset;
    private bool followCat = false;
    private bool flying = true;


    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

   
    private void Start()
    {
        
        CatapultCamera.transform.position = catapult.position + catapultOffset;
        FollowCamera.transform.position = Cat.transform.position + catOffset;

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(1))
        //{
        //    yaw += speedH * Input.GetAxis("Mouse X");
        //    pitch -= speedV * Input.GetAxis("Mouse Y");

            
        //    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        //}

        if (followCat)
        {
            CatapultCamera.enabled = false;
            FollowCamera.enabled = true;
        }
        else
        {
            CatapultCamera.enabled = true;
            FollowCamera.enabled = false;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            followCat = true;
        }

        if(Cat.GetComponent<CatControl>() != null)
        {
            flying = Cat.GetComponent<CatControl>().flying;
        }
        
        if (!flying)
        {
            followCat = false;
        }



    }
}
