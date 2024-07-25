using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioHighPassEffect : MonoBehaviour
{
    AudioSource audioSource;

    public float cutoffFrequency = 500.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioHighPassFilter highPassFilter = gameObject.GetComponent<AudioHighPassFilter>();
        highPassFilter.cutoffFrequency = cutoffFrequency;
    }
}
