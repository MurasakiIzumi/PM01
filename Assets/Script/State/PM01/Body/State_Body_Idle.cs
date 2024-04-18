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
        // �^�C�}�[�X�V
        if (body.isfired == true)
        {
            body.timer_nofire += Time.deltaTime;
        }

        if (body.timer_nofire > body.threshold_nofire)
        {
            body.isfired = false;
            body.timer_nofire = 0;
        }

        //�y��ԑJ�ځzShoot��Ԃ�
        if (Input.GetKey(KeyCode.L) == true)
        {
            if (body.isfired == false)
            {
                body.ChangeState(new Body_LaserShoot(body));
            }
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

        //�y��ԑJ�ځzJump��Ԃ�
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (body.player.Power >= 70.0f)
            {
                body.ChangeState(new Body_Jump(body));
            }
        }
    }

    public void Exit()
    {

    }
}