using UnityEngine;
using UnityEngine.SceneManagement;

public class TumblingCollision : MonoBehaviour {

    public AudioSource sound;

    void OnCollisionEnter(Collision collision) {
        if(collision.relativeVelocity.magnitude > 20) {
            sound.Play();
            //SceneManager.LoadScene(2); 
        }
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }
}
