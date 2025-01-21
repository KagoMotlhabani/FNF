using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip forest;
    public AudioClip cave;
    public AudioClip magic;
    public Movement player;

    void Start()
    {
        musicSource.clip = forest;
        musicSource.Play();

    }
}
