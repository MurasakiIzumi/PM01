using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BackArm_Shoot : IState
{
    private ControlBackArm backtarm;

    public BackArm_Shoot(ControlBackArm BackArm)
    {
        this.backtarm = BackArm;
    }

    public void Enter()
    {
        backtarm.SetAnimation("Shoot");
        backtarm.timer_noInput = 0;                // timer reset
    }

    public void Execute()
    {
        //タイマー更新
        if (Input.GetKey(KeyCode.J) == false)
        {
            backtarm.timer_noInput += Time.deltaTime;
        }

        //【状態遷移】Idle状態に
        if (backtarm.timer_noInput > backtarm.threshold_noInput)
        {
            backtarm.ChangeState(new BackArm_Idle(backtarm));
        }
    }

    public void Exit()
    {

    }
}