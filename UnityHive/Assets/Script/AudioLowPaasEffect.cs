using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioLowPaasEffect : MonoBehaviour
{
    AudioSource audioSource;

    public float cutoffFrequency = 500.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioLowPassFilter highPassFilter = gameObject.GetComponent<AudioLowPassFilter>();
        highPassFilter.cutoffFrequency = cutoffFrequency;
    }
}
