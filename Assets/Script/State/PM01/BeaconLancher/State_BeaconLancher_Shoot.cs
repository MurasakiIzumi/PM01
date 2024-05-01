using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class BeaconLancher_Shoot : IState
{
    private ControlBeaconLancher beaconlancher;

    public BeaconLancher_Shoot(ControlBeaconLancher BeaconLancher)
    {
        this.beaconlancher = BeaconLancher;
    }

    public void Enter()
    {
        beaconlancher.SetAnimation("Shoot");
    }

    public void Execute()
    {
        // アニメーションプレイ状態を取得
        var state = beaconlancher.animator.GetCurrentAnimatorStateInfo(0);

        // レーザー発射
        if (state.normalizedTime >= 0.5f)
        {
            if (beaconlancher.isfired == false)
            {
                beaconlancher.SetBeacon();
                beaconlancher.isfired = true;
            }
        }

        //　タイマー更新
        if (beaconlancher.isfired == true)
        {
            beaconlancher.timer_nofire += Time.deltaTime;
        }

        //【状態遷移】Idle状態に
        if (state.normalizedTime >= 1.0f)
        {

            beaconlancher.ChangeState(new BeaconLancher_Idle(beaconlancher));
        }
    }

    public void Exit()
    {

    }
}
