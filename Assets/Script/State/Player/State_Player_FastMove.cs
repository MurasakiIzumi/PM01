using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_State_FastMove : IState
{

    private ControlPlayer player;

    public Player_State_FastMove(ControlPlayer player)
    {
        this.player = player;
    }

    public void Enter()
    {
        //Debug.Log("‚‘¬ˆÚ“®ó‘Ô‚É“ü‚Á‚½");
        player.SetAnimation("FastMove");
        player.timer_noInput = 0;                // timer reset
    }

    public void Execute()
    {
        // “ü—Í
        float move_input_Hori = Input.GetAxisRaw("Horizontal");
        float move_input_Vert = Input.GetAxisRaw("Vertical");

        // Œü‚«’²®
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

        // À•WˆÚ“®ŒvZ
        player.transform.position += new Vector3(move_input_Hori, 0, 0) * player.move_speed * 3.0f * Time.deltaTime;
        player.transform.position += new Vector3(0, 0, move_input_Vert) * player.move_speed * Time.deltaTime;

        if ((Input.GetAxisRaw("Horizontal") == 0) && (Input.GetAxisRaw("Vertical") == 0))
        {
            player.timer_noInput += Time.deltaTime;
        } 

        //yó‘Ô‘JˆÚzIdleó‘Ô‚Éi“ü—Í‚µ‚Ä‚¢‚È‚¢ŠÔ‚ªè‡’l‚ğ’´‚¦‚é‚Æj
        if (player.timer_noInput > player.threshold_noInput)
        {
            player.ChangeState(new Player_State_Idle(player));
        }

        //yó‘Ô‘JˆÚzMoveó‘Ô‚É
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            player.ChangeState(new Player_State_Move(player));
        }
        if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            player.ChangeState(new Player_State_Move(player));
        }
    }

    public void Exit()
    {

    }
}
