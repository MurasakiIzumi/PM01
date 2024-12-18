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
            mortargun.player.BackAmmoName.text = "HE Shell";
        }
        else
        {
            mortargun.SetAnimation("Idle1");
            mortargun.player.BackAmmoName.text = "VT Shell";
        }
    }

    public void Execute()
    {
        //^C}[XV
        mortargun.timer_nofire += Time.deltaTime;

        //yóÔJÚzShootóÔÉ
        if ((Input.GetKey(KeyCode.K) == true) && mortargun.timer_nofire >= mortargun.threshold_nofire)
        {
            if (mortargun.player.ammorocket > 0)
            {
                mortargun.timer_nofire = 0.0f;
                mortargun.ChangeState(new MortarGun_Shoot(mortargun));
            }
        }

        // Ëp¨Ï·
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (mortargun.Mode)
            {
                mortargun.Mode = false;
                mortargun.SetAnimation("Idle1");
                mortargun.player.BackAmmoName.text = "VT Shell";
            }
            else
            {
                mortargun.Mode = true;
                mortargun.SetAnimation("Idle2");
                mortargun.player.BackAmmoName.text = "HE Shell";
            }
        }
    }

    public void Exit()
    {

    }
}
