using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Leg_FastMove : IState
{
    private ControlLeg leg;

    public Leg_FastMove(ControlLeg Leg)
    {
        this.leg = Leg;
    }

    public void Enter()
    {
        leg.SetAnimation("FastMove");
        leg.timer_noInput = 0;// timer reset
    }

    public void Execute()
    {
        // ����
        float move_input_Hori = Input.GetAxisRaw("Horizontal");
        float move_input_Vert = Input.GetAxisRaw("Vertical");

        // ��������
        if (move_input_Hori > 0 && leg.player.dir == 4)
        {
            leg.player.dir = 6;
            leg.player.SetSpriteFlip(false);
        }
        if (move_input_Hori < 0 && leg.player.dir == 6)
        {
            leg.player.dir = 4;
            leg.player.SetSpriteFlip(true);
        }

        // ���W�ړ��v�Z
        leg.player.transform.position += new Vector3(move_input_Hori, 0, 0) * leg.player.move_speed * 3.0f * Time.deltaTime;
        leg.player.transform.position += new Vector3(0, 0, move_input_Vert) * leg.player.move_speed * Time.deltaTime;

        //�^�C�}�[�X�V
        if ((Input.GetAxisRaw("Horizontal") == 0) && (Input.GetAxisRaw("Vertical") == 0))
        {
            leg.timer_noInput += Time.deltaTime;
        }

        //�y��ԑJ�ځzIdle��ԂɁi���͂��Ă��Ȃ����Ԃ�臒l�𒴂���Ɓj
        if (leg.timer_noInput > leg.threshold_noInput)
        {
            leg.ChangeState(new Leg_Idle(leg));
        }

        //�y��ԑJ�ځzMove��Ԃ�
        if ((Input.GetAxisRaw("Horizontal") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            leg.ChangeState(new Leg_Move(leg));
        }
        if ((Input.GetAxisRaw("Vertical") != 0) && (Input.GetKey(KeyCode.LeftShift) == false))
        {
            leg.ChangeState(new Leg_Move(leg));
        }
    }

    public void Exit()
    {

    }
}