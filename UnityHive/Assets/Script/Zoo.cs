using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal Tom = new Animal();
        Tom.name = "��";
        Tom.sound = "����";

        Tom.PlaySound();

        Animal bob = new Animal();
        bob.name = "��";
        bob.sound = "�п��ƶ����ξ���Ƥþ��";

        bob.PlaySound();   
    }

}
