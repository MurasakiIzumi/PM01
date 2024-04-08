using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class LaserGun_Shoot : IState
{
    private ControlLaserGun lasergun;

    public LaserGun_Shoot(ControlLaserGun LaserGun)
    {
        this.lasergun = LaserGun;
    }

    public void Enter()
    {
        lasergun.SetAnimation("Shoot");
    }

    public void Execute()
    {
        // �A�j���[�V�����v���C��Ԃ��擾
        var state = lasergun.animator.GetCurrentAnimatorStateInfo(0);

        // ���[�U�[����
        if(state.normalizedTime>=0.75f)
        {
            if (lasergun.isfired == false)
            {
                lasergun.SetLaser();
                lasergun.isfired = true;
            }
        }

        //�@�^�C�}�[�X�V
        if (lasergun.isfired == true)
        {
            lasergun.timer_nofire += Time.deltaTime;
        }

        //�y��ԑJ�ځzIdle��Ԃ�
        if (state.normalizedTime >= 1.0f)
        {

            lasergun.ChangeState(new LaserGun_Idle(lasergun));
        }
    }

    public void Exit()
    {

    }
}