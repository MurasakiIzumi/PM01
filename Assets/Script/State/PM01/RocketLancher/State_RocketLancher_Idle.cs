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
        //ÅyèÛë‘ëJà⁄ÅzShootèÛë‘Ç…
        if (Input.GetKey(KeyCode.K) == true)
        {
            rocketlancher.ChangeState(new RocketLancher_Shoot(rocketlancher));
        }
    }

    public void Exit()
    {

    }
}