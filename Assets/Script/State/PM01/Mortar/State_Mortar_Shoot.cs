using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class MortarGun_Shoot : IState
{
    private ControlMortarGun mortargun;
    private bool isfire;

    public MortarGun_Shoot(ControlMortarGun MortarGun)
    {
        this.mortargun = MortarGun;
    }

    public void Enter()
    {
        if (mortargun.Mode)
        {
            mortargun.SetAnimation("Shoot2");
        }
        else
        {
            mortargun.SetAnimation("Shoot1");
        }
        
        isfire = false;
    }

    public void Execute()
    {
        // �A�j���[�V�����v���C��Ԃ��擾
        var state = mortargun.animator.GetCurrentAnimatorStateInfo(0);

        if(!isfire)
        {
            mortargun.SetMortar();
            isfire = true;
        }

        //�y��ԑJ�ځzIdle��Ԃ�
        if (state.normalizedTime >= 1.0f)
        {
            mortargun.ChangeState(new MortarGun_Idle(mortargun));
        }
    }

    public void Exit()
    {

    }
}
