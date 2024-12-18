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

            // アニメーションプレイ状態を取得
            var state = mortargun.animator.GetCurrentAnimatorStateInfo(0);

            //【状態遷移】Idle状態に
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
