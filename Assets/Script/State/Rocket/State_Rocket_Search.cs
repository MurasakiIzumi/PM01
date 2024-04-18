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
        // ���W�ړ��v�Z
        rocket.transform.Translate(rocket.direction * rocket.speed * Time.deltaTime, Space.World);

        // �p�x�v�Z
        rocket.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        // �^�C�}�[�X�V
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