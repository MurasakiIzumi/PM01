using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class LaserGun_Shoot : IState
{
    private ControlLaserGun lasergun;

    public LaserGun_Shoot(ControlLaserGun LaserGun)
    {
        this.lasergun = LaserGun;
    }

    public void Enter()
    {
        lasergun.SetAnimation("Shoot");
    }

    public void Execute()
    {
        // ƒAƒjƒ[ƒVƒ‡ƒ“ƒvƒŒƒCó‘Ô‚ðŽæ“¾
        var state = lasergun.animator.GetCurrentAnimatorStateInfo(0);

        //yó‘Ô‘JˆÚzIdleó‘Ô‚É
        if (state.normalizedTime >= 1.0f)
        {
            lasergun.ChangeState(new LaserGun_Idle(lasergun));
        }
    }

    public void Exit()
    {

    }
}