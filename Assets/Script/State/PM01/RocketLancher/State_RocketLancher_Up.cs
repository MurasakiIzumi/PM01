using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketLancher_Up : IState
{
    private ControlRocketLancher rocketlancher;

    public RocketLancher_Up(ControlRocketLancher RocketLancher)
    {
        this.rocketlancher = RocketLancher;
    }

    public void Enter()
    {
        rocketlancher.SetAnimation("Up");
        rocketlancher.animator.speed = 0;
    }

    public void Execute()
    {
        if (rocketlancher.player.canRun)
        {
            rocketlancher.animator.speed = 1;

            // �A�j���[�V�����v���C��Ԃ��擾
            var state = rocketlancher.animator.GetCurrentAnimatorStateInfo(0);

            //�y��ԑJ�ځzIdle��Ԃ�
            if (state.normalizedTime >= state.length)
            {
                rocketlancher.ChangeState(new RocketLancher_Idle(rocketlancher));

            }
        }
    }

    public void Exit()
    {

    }
}