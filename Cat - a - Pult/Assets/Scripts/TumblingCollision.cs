using UnityEngine;

public class TumblingCollision : MonoBehaviour {

    public AudioSource sound;

<<<<<<< HEAD

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 20)
        {
            sound.Play();
         
=======
    void OnCollisionEnter(Collision collision) {
        if(collision.relativeVelocity.magnitude > 20) {
            sound.Play();
            //SceneManager.LoadScene(2); 
        }
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
>>>>>>> parent of 7125caf... More Fixes double check everything Jia does.
        }

    }

}
