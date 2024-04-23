using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserGun_Up : IState
{
    private ControlLaserGun lasergun;

    public LaserGun_Up(ControlLaserGun LaserGun)
    {
        this.lasergun = LaserGun;
    }

    public void Enter()
    {
        lasergun.SetAnimation("Up");
        lasergun.animator.speed = 0;
    }

    public void Execute()
    {
        if (lasergun.player.canRun)
        {
            lasergun.animator.speed = 0.75f;

            // �A�j���[�V�����v���C��Ԃ��擾
            var state = lasergun.animator.GetCurrentAnimatorStateInfo(0);

            //�y��ԑJ�ځzIdle��Ԃ�
            if (state.normalizedTime >= state.length)
            {
                lasergun.ChangeState(new LaserGun_Idle(lasergun));

            }
        }
    }

    public void Exit()
    {

    }
}