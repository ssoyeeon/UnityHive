using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public GameObject soyeon;
    public int Hp = 10;

    void Start()
    {
        Debug.Log("첫 함수 호출");
        Debug.LogWarning("꺅 큰일이야!");
        Debug.LogError("삐빅 삐빅 에러.. 에러 발생!!");
    }

    void Update()
    {
         if(Input.GetMouseButtonDown(0))
        {
            Hp--;
            switch (Hp)
            {
                case 0:
                    Debug.Log("으악 죽었어.. 너가 날 죽인거야!");
                    Destroy(soyeon);
                    break;
                case 1:
                    Debug.Log("나.. 마지막 한 대야..!");
                    break;
                case 2:
                    Debug.Log("나 너무 아파..");
                    break;
                case 3:
                    Debug.Log("진짜 더 때려??");
                    break;
                case 4:
                    Debug.Log("정말 이러기야?.. 이건 아니잖아!!");
                    break;
                case 5:
                    Debug.Log("나 이제 정말 반피야!!");
                    break;
                case 6:
                    Debug.Log("잠시만 잠시만 곧 반피야!!!!");
                    break;
                case 7:
                    Debug.Log("이러지마.. 정말 안돼.. 벌써 피가 7밖에 남지 않았어!");
                    break;
                case 8:
                    Debug.Log("이러지마! 내 HP는 10밖에 안된다고..!");
                    break;
                case 9:
                    Debug.Log("왜.. 때리는거야..?");
                    break;
                case 10:
                    Debug.Log("ㅎㅎ 안녕?");
                    break;
            }
        }
    }
}
