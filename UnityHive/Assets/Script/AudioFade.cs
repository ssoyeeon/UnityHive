using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{
    AudioSource audioSource;

    public float fadeDuration = 1.0f;

    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private float fadeTimer = 0.0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadingIn)
        {
            fadeTimer += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(fadeTimer/fadeDuration);

            if(audioSource.volume >= 1.0f)
            {
                isFadingIn = false;
                fadeTimer = 0.0f;
            }
        }
        if(isFadingOut)
        {
            fadeTimer += Time.deltaTime;
            audioSource.volume = Mathf.Clamp01(1.0f - (fadeTimer/fadeDuration));

            if(audioSource.volume <= 1.0f)
            {
                isFadingOut = false;
                fadeTimer = 0.0f;
                audioSource.Stop();
            }
        }
    }

    public void StartFadeIn()
    {
        isFadingIn=true;
        isFadingOut = false;
        fadeTimer = 0.0f;
        audioSource.Play();
    }

    public void StartFadeOut()
    {
        isFadingOut=true;
        isFadingIn = false;
        fadeTimer = 0.0f;
    }
}
