using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //������� �������� �Է°��� �����Ͽ� ���� 
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����ؼ� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xspeed, 0, zSpeed)
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        //������ �ٵ��� �ӵ��� newVelocity �Ҵ�
        playRigidbody.velocity = newVelocity;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playRigidbody.AddForce(new Vector3(0, 500.0f, 0));
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("���� �׾����"); 
    }
}
