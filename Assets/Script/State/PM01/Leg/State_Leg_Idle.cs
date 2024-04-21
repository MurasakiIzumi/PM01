using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg_Idle : IState
{
    private ControlLeg leg;

    public Leg_Idle(ControlLeg Leg)
    {
        this.leg = Leg;
    }

    public void Enter()
    {
        leg.SetAnimation("Idle");
    }

    public void Execute()
    {
        //ÅyèÛë‘ëJà⁄ÅzMoveèÛë‘Ç…
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            leg.ChangeState(new Leg_Move(leg));
        }
        if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            leg.ChangeState(new Leg_Move(leg));
        }

        if (leg.player.isJump == false)
        {
            if (leg.player.Power >= 10.0f)
            {
                //ÅyèÛë‘ëJà⁄ÅzFastMoveèÛë‘Ç…
                if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
                {
                    leg.ChangeState(new Leg_FastMove(leg));
                }
                if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
                {
                    leg.ChangeState(new Leg_FastMove(leg));
                }
            }
        }
    }

    public void Exit()
    {

    }
}