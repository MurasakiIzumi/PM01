using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketLancher_Up : IState
{
    private ControlRocketLancher rocketlancher;

    public RocketLancher_Up(ControlRocketLancher RocketLancher)
    {
        this.rocketlancher = RocketLancher;
    }

    public void Enter()
    {
        rocketlancher.SetAnimation("Up");
        rocketlancher.animator.speed = 0;
    }

    public void Execute()
    {
        if (rocketlancher.player.canRun)
        {
            rocketlancher.animator.speed = 1;

            // アニメーションプレイ状態を取得
            var state = rocketlancher.animator.GetCurrentAnimatorStateInfo(0);

            //【状態遷移】Idle状態に
            if (state.normalizedTime >= state.length)
            {
                rocketlancher.ChangeState(new RocketLancher_Idle(rocketlancher));

            }
        }
    }

    public void Exit()
    {

    }
}