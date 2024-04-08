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
        body.timer_noInput = 0;                // timer reset
    }

    public void Execute()
    {
        //ƒ^ƒCƒ}[XV
        if (Input.GetKey(KeyCode.L) == false)
        {
            body.timer_noInput += Time.deltaTime;
        }

        //yó‘Ô‘JˆÚzIdleó‘Ô‚É
        if (body.timer_noInput > body.threshold_noInput)
        {
            body.ChangeState(new Body_Idle(body));
        }
    }

    public void Exit()
    {

    }
}