using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MortarGun_Up : IState
{
    private ControlMortarGun mortargun;

    public MortarGun_Up(ControlMortarGun MortarGun)
    {
        this.mortargun = MortarGun;
    }

    public void Enter()
    {
        mortargun.SetAnimation("Up");
        mortargun.animator.speed = 0;
    }

    public void Execute()
    {
        if (mortargun.player.canRun)
        {
            mortargun.animator.speed = 1f;

            // ƒAƒjƒ[ƒVƒ‡ƒ“ƒvƒŒƒCó‘Ô‚ðŽæ“¾
            var state = mortargun.animator.GetCurrentAnimatorStateInfo(0);

            //yó‘Ô‘JˆÚzIdleó‘Ô‚É
            if (state.normalizedTime >= state.length)
            {
                mortargun.ChangeState(new MortarGun_Idle(mortargun));

            }
        }
    }

    public void Exit()
    {

    }
}
