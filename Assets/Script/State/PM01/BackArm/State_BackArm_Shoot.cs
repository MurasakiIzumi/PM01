using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BackArm_Shoot : IState
{
    private ControlBackArm backarm;

    private bool isfired;

    public BackArm_Shoot(ControlBackArm BackArm)
    {
        this.backarm = BackArm;
    }

    public void Enter()
    {
        backarm.SetAnimation("Shoot");
        backarm.timer_noInput = 0;                // timer reset
        backarm.timer_nofire = 0.125f;                 // timer reset
        isfired = true;
    }

    public void Execute()
    {
        //’e‚ð”­ŽË
        if (isfired == false)
        {
            backarm.SetBullet();
            isfired = true;
        }

        if (backarm.timer_nofire > backarm.threshold_nofire)
        {
            isfired = false;
            backarm.timer_nofire = 0;
        }

        //ƒ^ƒCƒ}[XV
        if (isfired == true)
        {
            backarm.timer_nofire += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.J) == false)
        {
            backarm.timer_noInput += Time.deltaTime;
        }

        //yó‘Ô‘JˆÚzIdleó‘Ô‚É
        if (backarm.timer_noInput > backarm.threshold_noInput)
        {
            backarm.ChangeState(new BackArm_Idle(backarm));
        }
    }

    public void Exit()
    {

    }
}