using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketLancher_Shoot : IState
{
    private ControlRocketLancher rocketlancher;
    private bool rocket1out;
    private bool rocket2out;
    private bool rocket3out;

    public RocketLancher_Shoot(ControlRocketLancher RocketLancher)
    {
        this.rocketlancher = RocketLancher;
    }

    public void Enter()
    {
        rocketlancher.SetAnimation("Shoot");

        rocket1out=false;
        rocket2out=false;
        rocket3out=false;
    }

    public void Execute()
    {
        // アニメーションプレイ状態を取得
        var state = rocketlancher.animator.GetCurrentAnimatorStateInfo(0);

        //ロケット発射
        if ((state.normalizedTime > 0.16f) && (rocket1out == false))
        {
            rocketlancher.SetRocket();
            rocket1out = true;
        }

        if ((state.normalizedTime > 0.5f) && (rocket2out == false))
        {
            rocketlancher.SetRocket();
            rocket2out = true;
        }

        if ((state.normalizedTime > 0.83f) && (rocket3out == false))
        {
            rocketlancher.SetRocket();
            rocket3out = true;
        }

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