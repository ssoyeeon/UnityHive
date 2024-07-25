using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEchoEffect : MonoBehaviour
{
    AudioSource audioSource;                //AudioSource 컴포넌트를 저장할 변수
    public float delay = 500.0f;            //에코 딜레이 시간 - 밀리초 1000단위 1초
    public float delayRatio = 0.5f;         //에코 감쇠 비율

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioEchoFilter echoFilter = gameObject.GetComponent<AudioEchoFilter>();
        echoFilter.delay = delay;
        echoFilter.decayRatio = delayRatio;
        
    }

}
