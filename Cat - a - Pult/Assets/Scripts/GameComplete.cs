using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameComplete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Level Complete");
//<<<<<<< HEAD
            //SceneManager.LoadScene(5);
//=======
            SceneManager.LoadScene(5);
//>>>>>>> 7db62b11e1b662c51a0eae291c094f31478c9e79
            Destroy(this.gameObject);
            
        }




    }
}
