using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusic : MonoBehaviour
{

    private static AudioSource player;
    private static AudioClip[] songs = new AudioClip[4];
    private static int curr = 0;
    public AudioSource inputplayer;
    public AudioClip[] inputmusic;
    private static bool nextsong = false;
    private static bool changevol = false;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("musicplayer");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start(){
        player = inputplayer;
        for(int i=0; i<inputmusic.Length; i++){
            songs[i] = inputmusic[i];
        }
        curr = 0;
        player.clip = songs[curr];
        player.Play();
        nextsong = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlaying == false)
        {
            curr++;
            if (curr >= songs.Length)
            {
                curr = 0;
            }
            player.clip = songs[curr];
            player.Play();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                nextsong = true;
            }

            if (Input.GetKeyUp(KeyCode.P) && nextsong)
            {
                player.Stop();
                curr++;
                if (curr >= songs.Length)
                {
                    curr = 0;
                }
                player.clip = songs[curr];
                player.Play();
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                changevol = true;
            }

            if (Input.GetKeyUp(KeyCode.O) && changevol)
            {
                player.mute = !player.mute;
            }
        }
    }
}
