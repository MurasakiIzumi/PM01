using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketLancher_Idle : IState
{
    private ControlRocketLancher rocketlancher;

    public RocketLancher_Idle(ControlRocketLancher RocketLancher)
    {
        this.rocketlancher = RocketLancher;
    }

    public void Enter()
    {
        rocketlancher.SetAnimation("Idle");
    }

    public void Execute()
    {
        //ƒ^ƒCƒ}[XV
        rocketlancher.timer_nofire += Time.deltaTime;

        //yó‘Ô‘JˆÚzShootó‘Ô‚É
        if ((Input.GetKey(KeyCode.K) == true)&&rocketlancher.timer_nofire>=rocketlancher.threshold_nofire)
        {
            if (rocketlancher.player.ammorocket > 0)
            {
                rocketlancher.timer_nofire = 0.0f;
                rocketlancher.ChangeState(new RocketLancher_Shoot(rocketlancher));
            }
        }
    }

    public void Exit()
    {

    }
}