using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg_FastMove : IState
{
    private ControlLeg leg;

    public Leg_FastMove(ControlLeg Leg)
    {
        this.leg = Leg;
    }

    public void Enter()
    {
        leg.SetAnimation("FastMove");
        leg.timer_noInput = 0;// timer reset
    }

    public void Execute()
    {
        // 入力
        float move_input_Hori = Input.GetAxisRaw("Horizontal");
        float move_input_Vert = Input.GetAxisRaw("Vertical");

        // 向き調整
        if (move_input_Hori > 0 && leg.player.dir == 4)
        {
            leg.player.dir = 6;
            leg.player.SetSpriteFlip(false);
        }
        if (move_input_Hori < 0 && leg.player.dir == 6)
        {
            leg.player.dir = 4;
            leg.player.SetSpriteFlip(true);
        }

        // 座標移動計算
        leg.player.transform.position += new Vector3(move_input_Hori, 0, 0) * leg.player.move_speed * 2.0f * Time.deltaTime;
        leg.player.transform.position += new Vector3(0, 0, move_input_Vert) * leg.player.move_speed * 1.5f * Time.deltaTime;

        //タイマー更新
        if ((Input.GetAxisRaw("Horizontal") == 0) && (Input.GetAxisRaw("Vertical") == 0))
        {
            leg.timer_noInput += Time.deltaTime;
        }

        //Powerが減る
        leg.player.Power -= leg.player.PowerreplySpeed * 1.5f * Time.deltaTime;

        //【状態遷移】Idle状態に（入力していない時間が閾値を超えると）
        if (leg.timer_noInput > leg.threshold_noInput)
        {
            leg.ChangeState(new Leg_Idle(leg));
        }

        //【状態遷移】Move状態に
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            leg.ChangeState(new Leg_Move(leg));
        }
        if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            leg.ChangeState(new Leg_Move(leg));
        }
        if(leg.player.Power<=0.0f)
        {
            leg.ChangeState(new Leg_Move(leg));
        }

        // ジャンプ中アニメーション調整
        if (leg.player.isJump == true)
        {
            leg.SetAnimation("Idle");
        }
    }

    public void Exit()
    {

    }
}