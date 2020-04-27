using UnityEngine;

public class Meow : MonoBehaviour {

    public AudioSource sound;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.M)) {
            sound.Play();
        }
    }
}
