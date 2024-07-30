using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    [System.Serializable]   //라이트에 의한 데미지 설정을 그룹화한 클래스

    public class LightDamageSetting
    {
        public float neaeDistance = 2f;         //가까운 거리 기준
        public float mediumDistance = 5f;       //중간 거리 기준
        public int nearDamage = 3;              //가까운 거리에서의 데미지
        public int mediumDamage = 2;            //중간 거리에서의 데미지
        public int farDamage = 1;               //먼 거리에서의 데미지
    }

    [System.Serializable]   //디렉셔널 라이트 데미지 설정을 그룹화한 클래스
    public class DirectionalLightSettings          
    {
        public int baseDamage = 1;                      //기본 데미지
        public int maxDamage = 5;                       //최대 데미지
        public float damageincreaseInterval = 2f;       //데미지 증가 간격
    }

    public float damageInterval = 1f;                               //데미지를 받는 간격
    public float nightThreshold = 0.2f;                             //밤으로 간주할 빛의 강도 임계값
    public float moveSpeed = 5f;                                    //이동속도
    public LightDamageSetting lightDamageSetting;                   //라이트 데미지 설정
    public DirectionalLightSettings directionalLightSettings;       //디렉셔널 라이트 데미지 설절

    private CharacterController controller;                         //캐릭터 컨트롤러 컴포넌트
    private Light[] sceneLights;                                    //Scene의 모든 라이트
    private int currentDirectionalLightDamage;                      //현재 디렉셔널 라이트 데미지
    private float lastDamageTime;                                   //마지막으로 데미지를 받은 시간
    private float lastDirectionalLightDamageTime;                   //마지막으로 디렉셔널 라이트 데미지가 증가한 시간
    private float cumulativeDamage;                                 //누적 데미지

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        sceneLights = FindObjectsOfType<Light>();                //Scene의 모든 라이트 찾기
        ResetDirectionalLightDamage();
    }

    void Update()
    {
        Move();
        HandleDamage();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    void ResetDirectionalLightDamage()              //디렉셔널 라이트 데미지 리셋
    {
        currentDirectionalLightDamage = directionalLightSettings.baseDamage;
    }

    void UpdateDirectionalLightDamage()             //디렉셔널 라이트 데미지 업데이트
    {
        //지속적으로 빛을 보고 있으면 데미지가 1씩 올라간다.
        if (Time.time - lastDirectionalLightDamageTime >= directionalLightSettings.damageincreaseInterval)
        {
            currentDirectionalLightDamage = Mathf.Min(currentDirectionalLightDamage + 1, directionalLightSettings.maxDamage);
            lastDirectionalLightDamageTime = Time.time;
        }
    }

    bool IsExposedToDirextionalLight()      //디렉셔널 라이트에 노출 되어있는지 확인
    {
        for(int i = 0; i < sceneLights.Length; i++)
        {
            if(sceneLights[i].type == LightType.Directional && !IsInDirectionalShadow(sceneLights[i]))
            {
                return true;
            }
        }
        return false;
    }
    
    bool IsExposedToAnyPointLight()
    {
        for (int i = 0; i < sceneLights.Length; i++)
        {
            if (sceneLights[i].type == LightType.Point && !IsExposedToPointLight(sceneLights[i]))
            {
                return true;
            }
        }
        return false;
    }

    void HandleDamage()
    {
        if(IsExposedToLight())                                  //플레이어가 빛에 노출 되어있는지 확인
        {
            if(Time.time - lastDamageTime >= damageInterval)    //틱 시간을 확인하고
            {
                TakeDamage();                                   //데미지를 계산 후 적용
            }
            UpdateDirectionalLightDamage();                     //다이렉셔널 ㅇㅁ낭 보여주세요!!!!! 왜 여기 안 보여주세요 여기 보여주세요
        }
        else
        {
            ResetDirectionalLightDamage();
        }
    }

    bool IsExposedToLight()
    {
        return IsExposedToDirextionalLight() || IsExposedToAnyPointLight();
    }
    bool IsInDirectionalShadow(Light light)         //디렉셔널 라이트의 그림자 안에 있는지 확인
    {
        const int rayCount = 5;
        const float rayRadius = 0.5f;
        int shadowCount = 0;

        for(int i = 0; i < rayCount; i++)
        {
            Vector3 rayStart = transform.position + Quaternion.Euler(0, i * 360f/ rayCount, 0) * (Vector3.forward * rayRadius);
            if(Physics.Raycast(rayStart, -light.transform.forward, out _))
            {
                shadowCount++;
            }
        }
        return shadowCount > rayCount / 2;
    }

    bool IsExposedToPointLight(Light light)         //포인트 라이트에 노출 되어있는지 확인
    {
        Vector3 dirextionToLight = light.transform.position - transform.position;
        return dirextionToLight.magnitude <= light.range &&
            !Physics.Raycast(transform.position, dirextionToLight.normalized, dirextionToLight.magnitude);
    }

    int CalculateDamage()               //데미지 계산
    {
        int damage = currentDirectionalLightDamage;
        float closestPointLightDistance = float.MaxValue;
        bool exposedToPointLight = false;

        for(int i = 0; i < sceneLights.Length; i++)
        {
            if(sceneLights[i].type == LightType.Point && IsExposedToPointLight(sceneLights[i]))
            {
                float distance = Vector3.Distance(transform.position, sceneLights[i].transform.position);
                if((distance < closestPointLightDistance))
                {
                    closestPointLightDistance = distance;
                    exposedToPointLight = true;
                }
            }
        }

        if (exposedToPointLight)        //포인트 라이트에 의한 데미지 계산
        {
            if(closestPointLightDistance <= lightDamageSetting.nearDamage)
            {
                if(closestPointLightDistance <= lightDamageSetting.nearDamage)
                damage += lightDamageSetting.nearDamage;
                else if(closestPointLightDistance <= lightDamageSetting.mediumDistance)
                    damage += lightDamageSetting.mediumDamage;
                else 
                    damage += lightDamageSetting.farDamage;
            }
        }
        return damage;
    }

    void TakeDamage()
    {
        int damage = CalculateDamage();
        cumulativeDamage += damage;
        lastDamageTime = Time.time;
        Debug.Log($"플레이가 데미지를 받음 :{damage}, 누적 데미지 : {cumulativeDamage}");
    }
}
