using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animal Tom = new Animal();
        Tom.name = "Åè";
        Tom.sound = "¿þ¿Ë";

        Tom.PlaySound();

        Animal bob = new Animal();
        bob.name = "¹ä";
        bob.sound = "¿Ð¿ù¾Æ¶û···Î¾î¤¿¤©¾Æ¤Ã¾î¿Ð";

        bob.PlaySound();   
    }

}
