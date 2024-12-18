using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class BeaconLancher_Up : IState
{
    private ControlBeaconLancher beaconlancher;

    public BeaconLancher_Up(ControlBeaconLancher BeaconLancher)
    {
        this.beaconlancher = BeaconLancher;
    }

    public void Enter()
    {
        beaconlancher.SetAnimation("Up");
        beaconlancher.animator.speed = 0;
    }

    public void Execute()
    {
        if (beaconlancher.player.canRun)
        {
            beaconlancher.animator.speed = 1f;

            // アニメーションプレイ状態を取得
            var state = beaconlancher.animator.GetCurrentAnimatorStateInfo(0);

            //【状態遷移】Idle状態に
            if (state.normalizedTime >= state.length)
            {
                beaconlancher.ChangeState(new BeaconLancher_Idle(beaconlancher));

            }
        }
    }

    public void Exit()
    {

    }
}
