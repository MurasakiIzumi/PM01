using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Body_Jump : IState
{
    private ControlBody body;
    private float Jumpspeed;
    private Vector3 target;
    private float timer;

    public Body_Jump(ControlBody Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("Jump");
        body.player.isJump = true;
        Jumpspeed = body.player.move_speed;
        timer = 0;
    }
    public void Execute()
    {
        body.player.transform.Translate(Vector3.up * Jumpspeed * Time.deltaTime, Space.World);

        if (timer >= 0.5f)
        {
            timer = 0;
            Jumpspeed *= 0.8f;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
        target = new Vector3(body.player.transform.position.x, body.player.jumphigh, body.player.transform.position.z);

        if ((Vector3.Distance(body.player.transform.position, target) < 0.1f))
        {
            body.player.transform.position = target;

            body.ChangeState(new Body_Fall(body,Jumpspeed));
        }
    }
    public void Exit()
    {

    }
}