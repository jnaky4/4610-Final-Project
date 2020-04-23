using UnityEngine;

public class PlayerCollision : MonoBehaviour
{   

    public PlayerMovement movement;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if(collision.collider.tag == "Bounce")
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
