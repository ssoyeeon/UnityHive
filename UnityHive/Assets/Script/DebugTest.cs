using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    public GameObject soyeon;
    public int Hp = 10;

    void Start()
    {
        Debug.Log("ù �Լ� ȣ��");
        Debug.LogWarning("�� ū���̾�!");
        Debug.LogError("�ߺ� �ߺ� ����.. ���� �߻�!!");
    }

    void Update()
    {
         if(Input.GetMouseButtonDown(0))
        {
            Hp--;
            switch (Hp)
            {
                case 0:
                    Debug.Log("���� �׾���.. �ʰ� �� ���ΰž�!");
                    Destroy(soyeon);
                    break;
                case 1:
                    Debug.Log("��.. ������ �� ���..!");
                    break;
                case 2:
                    Debug.Log("�� �ʹ� ����..");
                    break;
                case 3:
                    Debug.Log("��¥ �� ����??");
                    break;
                case 4:
                    Debug.Log("���� �̷����?.. �̰� �ƴ��ݾ�!!");
                    break;
                case 5:
                    Debug.Log("�� ���� ���� ���Ǿ�!!");
                    break;
                case 6:
                    Debug.Log("��ø� ��ø� �� ���Ǿ�!!!!");
                    break;
                case 7:
                    Debug.Log("�̷�����.. ���� �ȵ�.. ���� �ǰ� 7�ۿ� ���� �ʾҾ�!");
                    break;
                case 8:
                    Debug.Log("�̷�����! �� HP�� 10�ۿ� �ȵȴٰ�..!");
                    break;
                case 9:
                    Debug.Log("��.. �����°ž�..?");
                    break;
                case 10:
                    Debug.Log("���� �ȳ�?");
                    break;
            }
        }
    }
}
