using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserGun_Idle : IState
{
    private ControlLaserGun lasergun;

    public LaserGun_Idle(ControlLaserGun LaserGun)
    {
        this.lasergun = LaserGun;
    }

    public void Enter()
    {
        lasergun.SetAnimation("Idle");
    }

    public void Execute()
    {
        // ƒ^ƒCƒ}[XV
        if (lasergun.isfired == true)
        {
            lasergun.timer_nofire += Time.deltaTime;
        }

        if (lasergun.timer_nofire > lasergun.threshold_nofire)
        {
            lasergun.isfired = false;
            lasergun.timer_nofire = 0;
        }

        //yó‘Ô‘JˆÚzShootó‘Ô‚É
        if (Input.GetKey(KeyCode.L) == true)
        {
            if (lasergun.isfired == false)
            {
                if (lasergun.player.Power >= 50.0f)
                {
                    lasergun.ChangeState(new LaserGun_Shoot(lasergun));
                }
            }
        }
    }

    public void Exit()
    {

    }
}