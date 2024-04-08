using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserGun_Idle : IState
{
    private ControlLaserGun lasergun;

    public LaserGun_Idle(ControlLaserGun LaserGun)
    {
        this.lasergun = LaserGun;
    }

    public void Enter()
    {
        lasergun.SetAnimation("Idle");
    }

    public void Execute()
    {
        // �^�C�}�[�X�V
        if (lasergun.isfired == true)
        {
            lasergun.timer_nofire += Time.deltaTime;
        }

        if (lasergun.timer_nofire > lasergun.threshold_nofire)
        {
            lasergun.isfired = false;
            lasergun.timer_nofire = 0;
        }

        //�y��ԑJ�ځzShoot��Ԃ�
        if (Input.GetKey(KeyCode.L) == true)
        {
            if (lasergun.isfired == false)
            {
                lasergun.ChangeState(new LaserGun_Shoot(lasergun));
            }
        }
    }

    public void Exit()
    {

    }
}