using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Body_Fall : IState
{
    private ControlBody body;
    private float Jumpspeed;
    private float speedx;
    private float speedx1;
    private float speedx2;
    private Vector3 target;
    private float timer;

    public Body_Fall(ControlBody Body,float JumpSpeed)
    {
        this.body = Body;
        Jumpspeed = JumpSpeed;
    }

    public void Enter()
    {
        body.SetAnimation("Fall1");
        timer = 0;
        speedx = 0;
        speedx1 = 1.2f;
        speedx2 = 0.8f;
    }
    public void Execute()
    {
        body.player.transform.Translate(Vector3.down * Jumpspeed * Time.deltaTime, Space.World);

        if (timer >= 0.5f)
        {
            timer = 0;
            Jumpspeed *= speedx;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (body.player.transform.position.y <= body.player.jumphigh / 3)
        {
            speedx = speedx2;
            body.SetAnimation("Fall2");
        }
        else 
        {
            speedx = speedx1;
        }

        target = new Vector3(body.player.transform.position.x, 0, body.player.transform.position.z);

        if ((Vector3.Distance(body.player.transform.position, target) < 0.1f))
        {
            body.player.transform.position = target;
            body.player.isJump = false;
            body.ChangeState(new Body_Idle(body));
        }
    }
    public void Exit()
    {

    }
}