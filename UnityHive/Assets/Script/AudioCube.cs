using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCube : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    GameObject[] sampleCube = new GameObject[512];
    public float maxScale = 1000;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < sampleCube.Length; i++)
        {
            GameObject temp = Instantiate(sampleCubePrefab);
            temp.transform.position = this.transform.position;
            temp.transform.parent = this.transform;
            temp.name = "Cube" + i.ToString("000");
            this.transform.eulerAngles = new Vector3(0, -0.73125f * i, 0);
            temp.transform.position = Vector3.forward * 100;
            sampleCube[i] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < sampleCube.Length; i++)
        {
            if(sampleCube[i] != null)
            {
                sampleCube[i].transform.localScale
                    = new Vector3(10, (AudioPeer.samples[i] * maxScale) + 2, 10) * 0.1f;
            }
        }
    }
}
