using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public Rigidbody rig;

    void Start()
    {
        rig.AddForce(0, 500, 0);        //y������ 500��ŭ�� ���� ��
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
