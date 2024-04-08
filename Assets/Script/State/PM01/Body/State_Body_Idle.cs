using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Body_Idle : IState
{
    private ControlBody body;

    public Body_Idle(ControlBody Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("Idle");
    }

    public void Execute()
    {
        // ƒ^ƒCƒ}[XV
        if (body.isfired == true)
        {
            body.timer_nofire += Time.deltaTime;
        }

        if (body.timer_nofire > body.threshold_nofire)
        {
            body.isfired = false;
            body.timer_nofire = 0;
        }

        //yó‘Ô‘JˆÚzShootó‘Ô‚É
        if (Input.GetKey(KeyCode.L) == true)
        {
            if (body.isfired == false)
            {
                body.ChangeState(new Body_LaserShoot(body));
            }
        }

        //yó‘Ô‘JˆÚzFastMoveó‘Ô‚É
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            body.ChangeState(new Body_FastMove(body));
        }
        if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == true))
        {
            body.ChangeState(new Body_FastMove(body));
        }
    }

    public void Exit()
    {

    }
}