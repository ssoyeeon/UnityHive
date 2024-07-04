using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    public string characterName = "소연";
    public char bloodType = 'B';
    public int age = 19;
    public float height = 158.6f;
    public bool isFemale = true;
    public int love = 100;

    public int sum;
    void Start()
    {
        //형 변환 안 해도 되는데 해주는게 좋다
        Debug.Log("캐릭터 이름 : " + characterName);
        Debug.Log("혈액형 : " + bloodType);
        Debug.Log("나이 : " + age.ToString());
        Debug.Log("키 : " + height.ToString());
        Debug.Log("여성인가? : " + isFemale.ToString());

        float distance = GetDistance(2, 2, 5, 6);
        Debug.Log("(2,2)에서 (5,6)까지의 거리" + distance);

        if(love > 90)                   //love가 90보다 큰 경우
        {
            Debug.Log("트루 엔딩");
        }
        else if(love > 70)              //love가 90보다 작거나 같고, 70보다 큰  경우
        {
            Debug.Log("해피엔딩");
        }
        else                            //love가 70 초과 이외의 경우
        {
            Debug.Log("배드엔딩");
        }

        for(int i = 0; i < 10; i++)
        {
            //i는 1부터 시작하여 9가 될 때 까지 i를 1씩 증가시키며 Sum에 합산
            sum += i;
        }
        Debug.Log("1부터 9까지의 합은" + sum);

        for( int i = 1; i < 10; i++)        //9단
        {
            for(int j = 1; j < 10; j++)     //9단 총 81회 진행
            {
                int temp = i * j;                           //임의의 변수를 생성 하여 i 곱하기 j 값을 넣어준다.
                Debug.Log(i + "x" + j + " = " + temp);
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            love++;
        }
    }

    float GetDistance(float x1, float y1, float x2, float y2)   //두 점 사이의 거리를 계산하는 함수 [함수 이름 : GetDistance] [함수 리턴 변수 형 : float]
    {
        float width = x2 - x1;                                  //거리 값을 뺀다.
        float height = y2 - y1;

        float distance = width * width + height * height;       // w,h의 제곱값을 distance 변수 값에 넣어준다.
        distance = Mathf.Sqrt(distance);                        //루트를 씌워 준다.

        return distance;                                        //함수의 반환 값을 선언 해준다. ( 안 해주면 오류 뜬당. )
    }
}
