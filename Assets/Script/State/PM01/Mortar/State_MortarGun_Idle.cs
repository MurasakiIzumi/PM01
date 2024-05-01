using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MortarGun_Idle : IState
{
    private ControlMortarGun mortargun;

    public MortarGun_Idle(ControlMortarGun MortarGun)
    {
        this.mortargun = MortarGun;
    }

    public void Enter()
    {
        mortargun.SetAnimation("Idle1");
    }

    public void Execute()
    {
        //ƒ^ƒCƒ}[XV
        mortargun.timer_nofire += Time.deltaTime;

        //yó‘Ô‘JˆÚzShootó‘Ô‚É
        if ((Input.GetKey(KeyCode.K) == true) && mortargun.timer_nofire >= mortargun.threshold_nofire)
        {
            if (mortargun.player.ammorocket > 0)
            {
                mortargun.timer_nofire = 0.0f;
                mortargun.ChangeState(new MortarGun_Shoot(mortargun));
            }
        }
    }

    public void Exit()
    {

    }
}
