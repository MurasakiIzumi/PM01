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
        if (mortargun.Mode)
        {
            mortargun.SetAnimation("Idle2");
        }
        else
        {
            mortargun.SetAnimation("Idle1");
        }
    }

    public void Execute()
    {
        //É^ÉCÉ}Å[çXêV
        mortargun.timer_nofire += Time.deltaTime;

        //ÅyèÛë‘ëJà⁄ÅzShootèÛë‘Ç…
        if ((Input.GetKey(KeyCode.K) == true) && mortargun.timer_nofire >= mortargun.threshold_nofire)
        {
            if (mortargun.player.ammorocket > 0)
            {
                mortargun.timer_nofire = 0.0f;
                mortargun.ChangeState(new MortarGun_Shoot(mortargun));
            }
        }

        // éÀåÇépê®ïœä∑
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (mortargun.Mode)
            {
                mortargun.Mode = false;
                mortargun.SetAnimation("Idle1");
            }
            else
            {
                mortargun.Mode = true;
                mortargun.SetAnimation("Idle2");
            }
        }
    }

    public void Exit()
    {

    }
}
