using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Body_LaserShoot : IState
{
    private ControlBody body;

    public Body_LaserShoot(ControlBody Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("LaserShoot");
    }

    public void Execute()
    {
        // �A�j���[�V�����v���C��Ԃ��擾
        var state = body.animator.GetCurrentAnimatorStateInfo(0);

        // ���[�U�[����
        if (state.normalizedTime >= 0.75f)
        {
            if (body.isfired == false)
            {
                body.isfired = true;
            }
        }

        //�@�^�C�}�[�X�V
        if (body.isfired == true)
        {
            body.timer_nofire += Time.deltaTime;
        }

        //�y��ԑJ�ځzIdle��Ԃ�
        if (state.normalizedTime >= 1.0f)
        {

            body.ChangeState(new Body_Idle(body));
        }
    }

    public void Exit()
    {

    }
}