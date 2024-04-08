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
        //yó‘Ô‘JˆÚzShootó‘Ô‚É
        if (Input.GetKey(KeyCode.L) == true)
        {
            lasergun.ChangeState(new LaserGun_Shoot(lasergun));
        }
    }

    public void Exit()
    {

    }
}