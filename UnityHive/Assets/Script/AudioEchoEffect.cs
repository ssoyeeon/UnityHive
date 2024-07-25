using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEchoEffect : MonoBehaviour
{
    AudioSource audioSource;                //AudioSource ������Ʈ�� ������ ����
    public float delay = 500.0f;            //���� ������ �ð� - �и��� 1000���� 1��
    public float delayRatio = 0.5f;         //���� ���� ����

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        AudioEchoFilter echoFilter = gameObject.GetComponent<AudioEchoFilter>();
        echoFilter.delay = delay;
        echoFilter.decayRatio = delayRatio;
        
    }

}
