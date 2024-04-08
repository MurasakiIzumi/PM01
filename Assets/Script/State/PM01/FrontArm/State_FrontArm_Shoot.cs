using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FrontArm_Shoot : IState
{
    private ControlFrontArm frontarm;

    private bool isfired;

    public FrontArm_Shoot(ControlFrontArm FrontArm)
    {
        this.frontarm = FrontArm;
    }

    public void Enter()
    {
        frontarm.SetAnimation("Shoot");
        frontarm.timer_noInput = 0;                // timer reset
        frontarm.timer_nofire = 0;                 // timer reset
        isfired=false;
    }

    public void Execute()
    {
        //’e‚ð”­ŽË
        if (isfired == false)
        {
            frontarm.SetBullet();
            isfired = true;
        }

        if (frontarm.timer_nofire > frontarm.threshold_nofire)
        {
            isfired = false;
            frontarm.timer_nofire = 0;
        }

        //ƒ^ƒCƒ}[XV
        if (isfired == true)
        {
            frontarm.timer_nofire += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.J) == false)
        {
            frontarm.timer_noInput += Time.deltaTime;
        }

        //yó‘Ô‘JˆÚzIdleó‘Ô‚É
        if (frontarm.timer_noInput > frontarm.threshold_noInput)
        {
            frontarm.ChangeState(new FrontArm_Idle(frontarm));
        }
    }

    public void Exit()
    {

    }
}