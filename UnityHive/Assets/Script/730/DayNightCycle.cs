using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float cycleLength = 240f;                //하루 길이 (초)
    public Light dirextionalLight;                  //다이랙션 라이트를 받아온다.

    void Update()
    {
        float cycleCompletionPercentage = (Time.time % cycleLength) / cycleLength;      //상태 % (0~1)
        float sunAngle = cycleCompletionPercentage * 360f;                              //받아온 %에 360도를 곱함
        dirextionalLight.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0);      //시간에 따른 태양 빛 회전
    }
}
