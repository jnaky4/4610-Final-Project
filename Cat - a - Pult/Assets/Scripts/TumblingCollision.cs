using UnityEngine;

public class TumblingCollision : MonoBehaviour {

    public AudioSource sound;

    void OnCollisionEnter() {
        sound.Play();
    }
}
