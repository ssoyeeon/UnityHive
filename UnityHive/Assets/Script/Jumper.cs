using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public Rigidbody rig;

    void Start()
    {
        rig.AddForce(0, 500, 0);        //y√‡¿∏∑Œ 500∏∏≈≠¿« »˚¿ª ¡‹
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
