using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Body_LaserShoot : IState
{
    private ControlBody body;

    public Body_LaserShoot(ControlBody Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("LaserShoot");
    }

    public void Execute()
    {
        // アニメーションプレイ状態を取得
        var state = body.animator.GetCurrentAnimatorStateInfo(0);

        // レーザー発射
        if (state.normalizedTime >= 0.75f)
        {
            if (body.isfired == false)
            {
                body.isfired = true;
            }
        }

        //　タイマー更新
        if (body.isfired == true)
        {
            body.timer_nofire += Time.deltaTime;
        }

        //【状態遷移】Idle状態に
        if (state.normalizedTime >= 1.0f)
        {

            body.ChangeState(new Body_Idle(body));
        }
    }

    public void Exit()
    {

    }
}