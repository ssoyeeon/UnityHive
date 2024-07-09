using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public int Hp = 10;                 //ü�� ���� 
    public float Distance = 0;          //�̵� �Ÿ� 

    public int NeedHp = 2;
    public float MoveDistance = 3.5f;

    void Start()
    {
    }

    void ObjectMove(int _Hp, float _MoveDistance)
    {
        Hp = Hp - _Hp;                              //�Լ� ������ �� �μ��� �ݾƿ� Hp�� ����.
        Distance = Distance + _MoveDistance;        //�Լ� ������ �� �μ��� �޾ƿ� �Ÿ��� ���Ѵ�. 

        Debug.Log("���� ü�� : " + Hp);
        Debug.Log("�̵� �Ÿ�  : " + Distance);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))                     //Ű �Է��� ���� Update���� ���� �ϰ� if���� ���ؼ� Ű�� �Է��� �Ǿ��� ��
        {
            if(NeedHp > Hp)
            {
                Debug.Log("�� �̻� �̵� �� �� �����ϴ�.");     //ü���� �����Ƿ� �̵� �� �� ����.
            }
            else
            {
                ObjectMove(NeedHp, MoveDistance);               //�Լ��� ���� �̵� ��Ų��.
                this.gameObject.transform.position = new Vector3(0, Distance, 0);       // �� ������Ʈ�� �̵� ��Ų��.
            }
        }
    }
}
