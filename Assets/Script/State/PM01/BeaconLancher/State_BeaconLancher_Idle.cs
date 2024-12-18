using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class BeaconLancher_Idle : IState
{
    private ControlBeaconLancher beaconlancher;

    public BeaconLancher_Idle(ControlBeaconLancher BeaconLancher)
    {
        this.beaconlancher = BeaconLancher;
    }

    public void Enter()
    {
        beaconlancher.SetAnimation("Idle");
    }

    public void Execute()
    {
        // タイマー更新
        if (beaconlancher.isfired == true)
        {
            beaconlancher.timer_nofire += Time.deltaTime;
        }

        if (beaconlancher.timer_nofire > beaconlancher.threshold_nofire)
        {
            beaconlancher.isfired = false;
            beaconlancher.timer_nofire = 0;
        }

        //【状態遷移】Shoot状態に
        if (Input.GetKey(KeyCode.L) == true)
        {
            if (beaconlancher.isfired == false)
            {
                if (beaconlancher.player.Power >= 50.0f)
                {
                    beaconlancher.ChangeState(new BeaconLancher_Shoot(beaconlancher));
                }
            }
        }
    }

    public void Exit()
    {

    }
}
