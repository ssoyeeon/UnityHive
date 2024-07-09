using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal
{
    public string name;
    public string sound;
    
    public void PlaySound()
    {
        Debug.Log(name + " : " + sound);        //디버그 로그로 이름과 울음소리를 출력한다.
    }
    
}
