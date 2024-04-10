using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Rocket_Up : IState
{
    private RocketContrl rocket;
    private float timer;
    private float statetime;
    private float angle;

    public Rocket_Up(RocketContrl Rocket)
    {
        this.rocket = Rocket;
    }

    public void Enter()
    {
        rocket.GetComponent<Rigidbody>().useGravity = false;
        rocket.GetComponent<Rigidbody>().isKinematic = true;
        timer = 0.0f;
        statetime = 0.3f;
        if(rocket.speed>0)
        {
            rocket.direction = new Vector3(0.5f, 0.866f, 0);
            angle = 60.0f;
        }
        else
        {
            rocket.direction = new Vector3(0.5f, -0.866f, 0);
            angle = 120.0f;
        }
        
}

public void Execute()
    {
        // ���W�ړ��v�Z
        rocket.transform.Translate(rocket.direction * rocket.speed * 0.667f * Time.deltaTime, Space.World);

        // �p�x�v�Z
        rocket.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // �^�C�}�[�X�V
        timer += Time.deltaTime;

        if (timer >= statetime)
        {
            rocket.ChangeState(new Rocket_Search(rocket));
        }
    }

    public void Exit()
    {

    }
}