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
        //�y��ԑJ�ځzShoot��Ԃ�
        if (Input.GetKey(KeyCode.L) == true)
        {
            lasergun.ChangeState(new LaserGun_Shoot(lasergun));
        }
    }

    public void Exit()
    {

    }
}