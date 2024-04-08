using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class FrontArm_Shoot : IState
{
    private ControlFrontArm frontarm;

    public FrontArm_Shoot(ControlFrontArm FrontArm)
    {
        this.frontarm = FrontArm;
    }

    public void Enter()
    {
        frontarm.SetAnimation("Shoot");
        frontarm.timer_noInput = 0;                // timer reset
    }

    public void Execute()
    {
        //ƒ^ƒCƒ}[XV
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