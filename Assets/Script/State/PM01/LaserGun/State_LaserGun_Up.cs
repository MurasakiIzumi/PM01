using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserGun_Up : IState
{
    private ControlLaserGun lasergun;

    public LaserGun_Up(ControlLaserGun LaserGun)
    {
        this.lasergun = LaserGun;
    }

    public void Enter()
    {
        lasergun.SetAnimation("Up");
        lasergun.animator.speed = 0;
    }

    public void Execute()
    {
        if (lasergun.player.canRun)
        {
            lasergun.animator.speed = 0.75f;

            // ƒAƒjƒ[ƒVƒ‡ƒ“ƒvƒŒƒCó‘Ô‚ðŽæ“¾
            var state = lasergun.animator.GetCurrentAnimatorStateInfo(0);

            //yó‘Ô‘JˆÚzIdleó‘Ô‚É
            if (state.normalizedTime >= state.length)
            {
                lasergun.ChangeState(new LaserGun_Idle(lasergun));

            }
        }
    }

    public void Exit()
    {

    }
}