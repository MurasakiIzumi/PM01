using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BackArm_Idle : IState
{
    private ControlBackArm backarm;

    public BackArm_Idle(ControlBackArm BackArm)
    {
        this.backarm = BackArm;
    }

    public void Enter()
    {
        backarm.SetAnimation("Idle");
    }

    public void Execute()
    {
        //yó‘Ô‘JˆÚzShootó‘Ô‚É
        if (Input.GetKey(KeyCode.J) == true)
        {
            if (backarm.player.ammoleft > 0)
            {
                backarm.ChangeState(new BackArm_Shoot(backarm));
            }
        }
    }

    public void Exit()
    {

    }
}