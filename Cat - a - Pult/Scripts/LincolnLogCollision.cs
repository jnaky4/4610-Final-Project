using UnityEngine;

public class LincolnLogCollision : MonoBehaviour {

    public AudioSource wood;

    void OnCollisionEnter() {
        wood.Play();
    }
}
