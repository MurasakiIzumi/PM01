using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketLancher_Shoot : IState
{
    private ControlRocketLancher rocketlancher;

    public RocketLancher_Shoot(ControlRocketLancher RocketLancher)
    {
        this.rocketlancher = RocketLancher;
    }

    public void Enter()
    {
        rocketlancher.SetAnimation("Shoot");
    }

    public void Execute()
    {
        // �A�j���[�V�����v���C��Ԃ��擾
        var state = rocketlancher.animator.GetCurrentAnimatorStateInfo(0);

        //�y��ԑJ�ځzIdle��Ԃ�
        if (state.normalizedTime >= 1.0f)
        {
            rocketlancher.ChangeState(new RocketLancher_Idle(rocketlancher));
        }
    }

    public void Exit()
    {

    }
}