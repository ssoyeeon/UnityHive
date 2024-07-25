using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioReverbEffect : MonoBehaviour
{
    AudioSource audioSource;

    public AudioReverbPreset reverbPreset = AudioReverbPreset.Cave;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioReverbFilter reverbFilter = gameObject.GetComponent<AudioReverbFilter>();
        reverbFilter.reverbPreset = reverbPreset;
    }
}
