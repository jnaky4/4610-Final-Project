using UnityEngine;
using UnityEngine.SceneManagement;

public class TumblingCollision : MonoBehaviour {

    public AudioSource sound;

    void OnCollisionEnter(Collision collision) {
        if(collision.relativeVelocity.magnitude > 20) {
            sound.Play();
<<<<<<< HEAD
            //SceneManager.LoadScene(2); 
        }
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(5);
=======
>>>>>>> 7125cafed11c2a9eb8789a60adb22ced4205e461
        }
    }
}
