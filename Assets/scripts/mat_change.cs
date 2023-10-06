using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mat_change : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    private float nextActionTime = 0.0f;
    public float period = 0.5f;
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            colorSwitch();
            
        }

    }

    void colorSwitch()
    {
        if (x < 2)
        {
            x++;
        }
        else
        {
            x = 0;
        }
        rend.sharedMaterial = material[x];
    }
}
;