using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_State_Move : IState
{

    private ControlPlayer player;

    public Player_State_Move(ControlPlayer player)
    {
        this.player = player;
    }

    public void Enter()
    {
        //Debug.Log("移動状態に入った");
        player.SetAnimation("Move");
        player.timer_noInput = 0;                // timer reset
    }

    public void Execute()
    {
        // 入力
        float move_input_Hori = Input.GetAxisRaw("Horizontal");
        float move_input_Vert = Input.GetAxisRaw("Vertical");

        // 向き調整
        if (move_input_Hori > 0 && player.dir == 4)
        {
            player.dir = 6;
            player.spriteRenderer.flipX = false;
        }
        if (move_input_Hori < 0 && player.dir == 6)
        {
            player.dir = 4;
            player.spriteRenderer.flipX = true;
        }

        // 座標移動計算
        player.transform.position += new Vector3(move_input_Hori, 0, move_input_Vert) * player.move_speed * Time.deltaTime;


        if ((Input.GetAxisRaw("Horizontal") == 0)&& (Input.GetAxisRaw("Vertical") == 0))
        {
            player.timer_noInput += Time.deltaTime;
        }

        //【状態遷移】Idle状態に（入力していない時間が閾値を超えると）
        if (player.timer_noInput > player.threshold_noInput)
        {
            player.ChangeState(new Player_State_Idle(player));
        }

        //【状態遷移】FastMove状態に
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            player.ChangeState(new Player_State_FastMove(player));
        }
        if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            player.ChangeState(new Player_State_FastMove(player));
        }
    }

    public void Exit()
    {

    }
}
