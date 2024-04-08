using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FrontArm_Idle : IState
{
    private ControlFrontArm frontarm;

    public FrontArm_Idle(ControlFrontArm FrontArm)
    {
        this.frontarm = FrontArm;
    }

    public void Enter()
    {
        frontarm.SetAnimation("Idle");
    }

    public void Execute()
    {
        //�y��ԑJ�ځzShoot��Ԃ�
        if (Input.GetKey(KeyCode.J) == true)
        {
            frontarm.ChangeState(new FrontArm_Shoot(frontarm));
        }
    }

    public void Exit()
    {

    }
}