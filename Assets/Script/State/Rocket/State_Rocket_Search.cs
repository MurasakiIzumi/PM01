using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Rocket_Search : IState
{
    private RocketContrl rocket;
    private float timer;
    private float statetime;
    private float angle;

    public Rocket_Search(RocketContrl Rocket)
    {
        this.rocket = Rocket;
    }

    public void Enter()
    {
        rocket.GetComponent<Collider>().enabled = true;

        timer = 0.0f;
        statetime = 2.0f;
        rocket.direction = new Vector3(1.0f, 0, 0);

        if (rocket.speed > 0)
        {
            angle = 0.0f;
        }
        else 
        {
            angle = 180.0f;
        }
    }

    public void Execute()
    {
        // 座標移動計算
        rocket.transform.Translate(rocket.direction * rocket.speed * Time.deltaTime, Space.World);

        // 角度計算
        rocket.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        // タイマー更新
        timer += Time.deltaTime;

        if (timer >= statetime)
        {
            rocket.DestroySelf();
        }
    }

    public void Exit()
    {

    }
}