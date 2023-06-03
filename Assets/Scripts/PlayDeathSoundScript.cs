using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayDeathSoundScript : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;

    void Start()
    {
    }

    public float PlaySound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
        return audioSource.clip.length;
    }
    
}
