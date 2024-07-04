using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCode : MonoBehaviour
{
    public string characterName = "�ҿ�";
    public char bloodType = 'B';
    public int age = 19;
    public float height = 158.6f;
    public bool isFemale = true;
    public int love = 100;

    public int sum;
    void Start()
    {
        //�� ��ȯ �� �ص� �Ǵµ� ���ִ°� ����
        Debug.Log("ĳ���� �̸� : " + characterName);
        Debug.Log("������ : " + bloodType);
        Debug.Log("���� : " + age.ToString());
        Debug.Log("Ű : " + height.ToString());
        Debug.Log("�����ΰ�? : " + isFemale.ToString());

        float distance = GetDistance(2, 2, 5, 6);
        Debug.Log("(2,2)���� (5,6)������ �Ÿ�" + distance);

        if(love > 90)                   //love�� 90���� ū ���
        {
            Debug.Log("Ʈ�� ����");
        }
        else if(love > 70)              //love�� 90���� �۰ų� ����, 70���� ū  ���
        {
            Debug.Log("���ǿ���");
        }
        else                            //love�� 70 �ʰ� �̿��� ���
        {
            Debug.Log("��忣��");
        }

        for(int i = 0; i < 10; i++)
        {
            //i�� 1���� �����Ͽ� 9�� �� �� ���� i�� 1�� ������Ű�� Sum�� �ջ�
            sum += i;
        }
        Debug.Log("1���� 9������ ����" + sum);

        for( int i = 1; i < 10; i++)        //9��
        {
            for(int j = 1; j < 10; j++)     //9�� �� 81ȸ ����
            {
                int temp = i * j;                           //������ ������ ���� �Ͽ� i ���ϱ� j ���� �־��ش�.
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

    float GetDistance(float x1, float y1, float x2, float y2)   //�� �� ������ �Ÿ��� ����ϴ� �Լ� [�Լ� �̸� : GetDistance] [�Լ� ���� ���� �� : float]
    {
        float width = x2 - x1;                                  //�Ÿ� ���� ����.
        float height = y2 - y1;

        float distance = width * width + height * height;       // w,h�� �������� distance ���� ���� �־��ش�.
        distance = Mathf.Sqrt(distance);                        //��Ʈ�� ���� �ش�.

        return distance;                                        //�Լ��� ��ȯ ���� ���� ���ش�. ( �� ���ָ� ���� ���. )
    }
}
