using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public static AudioSource currentAudioSource;
    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
        AudioController.currentAudioSource = this.audioSource;
    }
}
