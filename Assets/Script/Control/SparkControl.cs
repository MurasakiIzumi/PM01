using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkControl : MonoBehaviour
{
    public ParticleSystem ParticleSystem1;
    public ParticleSystem ParticleSystem2;
    public ParticleSystem ParticleSystem3;

    public float OverTime;
    private bool isOver1;
    private bool isOver2;
    private bool isOver3;

    void Start()
    {
        isOver1 = false;
        isOver2 = false;
        isOver3 = false;
    }

    void Update()
    {
        if (ParticleSystem1)
        {
            if (ParticleSystem1.time >= OverTime)
            {
                isOver1 = true;
            }
        }
        else { isOver1 = true; }

        if (ParticleSystem2)
        {
            if (ParticleSystem2.time >= OverTime)
            {
                isOver2 = true;
            }
        }
        else { isOver2 = true; }

        if (ParticleSystem3)
        {
            if (ParticleSystem3.time >= OverTime)
            {
                isOver3 = true;
            }
        }
        else { isOver3 = true; }

        if (isOver1 && isOver2 && isOver3)
        {
            Destroy(gameObject);
        }
    }
}
