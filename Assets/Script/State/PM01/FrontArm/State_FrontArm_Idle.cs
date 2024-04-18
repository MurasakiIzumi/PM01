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
        //yó‘Ô‘JˆÚzShootó‘Ô‚É
        if (Input.GetKey(KeyCode.J) == true)
        {
            if (frontarm.player.ammoright > 0)
            {
                frontarm.ChangeState(new FrontArm_Shoot(frontarm));
            }
        }
    }

    public void Exit()
    {

    }
}