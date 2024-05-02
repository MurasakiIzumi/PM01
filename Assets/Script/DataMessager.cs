using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMessager : MonoBehaviour
{
    public int Arm1 = 1;
    public int Arm2 = 1;
    public int Shoulder1 = 1;
    public int Shoulder2 = 1;

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
