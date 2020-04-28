
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    public Transform player;
    public GameObject Cat;
    
    
    public Vector3 catapultOffset;
    public Vector3 catOffset;
    private bool followCat = false;
    private bool flying = true;

    // Update is called once per frame
    void Update()
    {
        
        if (followCat)
        {
            transform.position = Cat.transform.position + catOffset;
        }
        else
        {
            transform.position = player.position + catapultOffset;
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
