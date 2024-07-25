using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDistortionEffect : MonoBehaviour
{
    AudioSource audioSource;

    public float distortionLevel = 0.5f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioDistortionFilter distortionFilter = gameObject.GetComponent<AudioDistortionFilter>();
        distortionFilter.distortionLevel = distortionLevel;
    }
}
