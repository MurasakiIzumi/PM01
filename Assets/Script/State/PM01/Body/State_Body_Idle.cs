using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Body_Idle : IState
{
    private ControlBody body;

    public Body_Idle(ControlBody Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("Idle");
    }

    public void Execute()
    {
        // タイマー更新
        if (body.isfired == true)
        {
            body.timer_nofire += Time.deltaTime;
        }

        if (body.timer_nofire > body.threshold_nofire)
        {
            body.isfired = false;
            body.timer_nofire = 0;
        }

        //【状態遷移】Shoot状態に
        if (Input.GetKey(KeyCode.L) == true)
        {
            if (body.isfired == false)
            {
                body.ChangeState(new Body_LaserShoot(body));
            }
        }

        //【状態遷移】FastMove状態に
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            body.ChangeState(new Body_FastMove(body));
        }
        if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            body.ChangeState(new Body_FastMove(body));
        }

        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            body.ChangeState(new Body_Jump(body));
        }
    }

    public void Exit()
    {

    }
}