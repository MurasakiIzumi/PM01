using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_State_Idle : IState
{
    private ControlPlayer player;

    public Player_State_Idle(ControlPlayer player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.SetAnimation("Idle");
    }

    public void Execute()
    {

        //【状態遷移】Move状態に
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            player.ChangeState(new Player_State_Move(player));
        }

        //【状態遷移】FastMove状態に
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            player.ChangeState(new Player_State_FastMove(player));
        }
    }

    public void Exit()
    {

    }
}
