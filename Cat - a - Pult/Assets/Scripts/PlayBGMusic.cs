using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayBGMusic : MonoBehaviour
{

    public AudioSource player;
    public AudioClip[] songs;
    private int curr;
    private bool nextsong;
    // Start is called before the first frame update
    void Start()
    {
        curr = 0;
        player.clip = songs[curr];
        player.Play();
        nextsong = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isPlaying == false)
        {
            curr++;
            if(curr >= songs.Length)
            {
                curr = 0;
            }
            player.clip = songs[curr];
            player.Play();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                nextsong = true;
            }

            if (Input.GetKeyUp(KeyCode.Q) && nextsong)
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
        }
    }
}
