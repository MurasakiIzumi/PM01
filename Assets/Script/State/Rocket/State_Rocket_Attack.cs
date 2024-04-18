using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Rocket_Attack : IState
{
    private RocketContrl rocket;
    private float lerp;
    private float angle;

    public Rocket_Attack(RocketContrl Rocket)
    {
        this.rocket = Rocket;
    }

    public void Enter()
    {
        rocket.gameObject.tag = "Rocket";
        lerp = 0.025f;
        if (rocket.speed > 0)
        {
            angle = -45.0f;
        }
        else
        {
            angle = -135.0f;
        }
    }

    public void Execute()
    {
        if (rocket.target)
        {
            // ç¿ïWà⁄ìÆåvéZ
            rocket.transform.position = Vector3.Lerp(rocket.transform.position, rocket.target.transform.position, lerp);

            // äpìxåvéZ
            rocket.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        else
        {
            rocket.DestroySelf();
        }
    }

    public void Exit()
    {

    }
}