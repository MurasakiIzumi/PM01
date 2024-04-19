using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int timer;
    private float time;
    private int Minutes;
    private int Second;

    [HideInInspector] public int TotalTime;
    [HideInInspector] public bool isTimeOut;
    [HideInInspector] public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        isTimeOut = false;
        isRunning = false;
        timer = TotalTime;
        Minutes = timer / 60;
        Second = timer % 60;

        gameObject.GetComponent<Text>().fontSize = 40;
        gameObject.GetComponent<Text>().text = "0"+ Minutes+" : 0"+ Second;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeOut != true)
        {
            if (isRunning)
            {
                time += Time.deltaTime;
            }
        }

        if (time >= 1.0f)
        {
            timer--;
            time = 0;
        }

        Minutes = timer / 60;
        Second = timer % 60;

        if (isTimeOut != true)
        {
            if (Second < 10)
            {
                gameObject.GetComponent<Text>().text = "0" + Minutes + " : 0" + Second;
            }
            else
            {
                gameObject.GetComponent<Text>().text = "0" + Minutes + " : " + Second;
            }
        }

        if (timer <= 10)
        {
            gameObject.GetComponent<Text>().color= Color.red;
        }
        else if(timer<=30)
        {
            gameObject.GetComponent<Text>().color = Color.yellow;
        }

        if (timer < 0)
        {
            timer = 0;
            gameObject.GetComponent<Text>().fontSize = 35;
            gameObject.GetComponent<Text>().text = "Time Out";
            isTimeOut=true;
        }
    }
}
