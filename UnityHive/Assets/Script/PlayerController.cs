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
        //수평축과 수직축의 입력값을 감지하여 저장 
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해서 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xspeed, 0, zSpeed)
        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);

        //리지드 바디의 속도에 newVelocity 할당
        playRigidbody.velocity = newVelocity;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playRigidbody.AddForce(new Vector3(0, 500.0f, 0));
        }
    }
    public void Die()
    {
        gameObject.SetActive(false);
        Debug.Log("으앙 죽었당ㅜ"); 
    }
}
