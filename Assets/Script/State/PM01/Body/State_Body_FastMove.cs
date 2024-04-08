using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Body_FastMove : IState
{
    private ControlBody body;

    public Body_FastMove(ControlBody Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("FastMove");
        body.timer_noInput = 0;// timer reset
    }

    public void Execute()
    {
        //タイマー更新
        if ((Input.GetAxisRaw("Horizontal") == 0) && (Input.GetAxisRaw("Vertical") == 0))
        {
            body.timer_noInput += Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            body.timer_noInput += Time.deltaTime;
        }

        //【状態遷移】Idle状態に（入力していない時間が閾値を超えると）
        if (body.timer_noInput > body.threshold_noInput)
        {
            body.ChangeState(new Body_Idle(body));
        }
    }

    public void Exit()
    {

    }
}