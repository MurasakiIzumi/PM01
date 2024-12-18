using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Rocket_Idle : IState
{
    private RocketContrl rocket;
    private float timer;
    private float statetime;

    public Rocket_Idle(RocketContrl Rocket)
    {
        this.rocket = Rocket;
    }

    public void Enter()
    {
        timer = 0.0f;
        statetime = 0.3f;
        rocket.direction = new Vector3(1.0f, 0, 0);
    }

    public void Execute()
    {
        // 座標移動計算
        rocket.transform.Translate(rocket.direction * rocket.speed * Time.deltaTime, Space.World);

        // タイマー更新
        timer += Time.deltaTime;

        if (timer >= statetime)
        {
            rocket.ChangeState(new Rocket_Up(rocket));
        }
    }

    public void Exit()
    {

    }
}