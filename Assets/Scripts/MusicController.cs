using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private AudioClip intro = null;
    [SerializeField] private AudioClip loop = null;


    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying && !GetComponent<AudioSource>().loop) {
            GetComponent<AudioSource>().clip = loop;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
    }

    public void ResetMusic() {
        GetComponent<AudioSource>().clip = intro;
        GetComponent<AudioSource>().loop = false;
        GetComponent<AudioSource>().Play();
    }
}
