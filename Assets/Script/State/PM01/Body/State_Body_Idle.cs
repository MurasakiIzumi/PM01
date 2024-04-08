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
        //�y��ԑJ�ځzShoot��Ԃ�
        if (Input.GetKey(KeyCode.L) == true)
        {
            body.ChangeState(new Body_LaserShoot(body));
        }

        //�y��ԑJ�ځzFastMove��Ԃ�
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            body.ChangeState(new Body_FastMove(body));
        }
        if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            body.ChangeState(new Body_FastMove(body));
        }
    }

    public void Exit()
    {

    }
}