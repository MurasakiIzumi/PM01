using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketLancher_Shoot : IState
{
    private ControlRocketLancher rocketlancher;

    public RocketLancher_Shoot(ControlRocketLancher RocketLancher)
    {
        this.rocketlancher = RocketLancher;
    }

    public void Enter()
    {
        rocketlancher.SetAnimation("Shoot");
    }

    public void Execute()
    {
        // アニメーションプレイ状態を取得
        var state = rocketlancher.animator.GetCurrentAnimatorStateInfo(0);

        //【状態遷移】Idle状態に
        if (state.normalizedTime >= 1.0f)
        {
            rocketlancher.ChangeState(new RocketLancher_Idle(rocketlancher));
        }
    }

    public void Exit()
    {

    }
}