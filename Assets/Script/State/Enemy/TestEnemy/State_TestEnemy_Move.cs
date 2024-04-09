using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TestEnemy_Move : IState
{
    private ControlTestEnemy testenemy;
    private Vector3 targetpos;
    private int nextturn;

    public TestEnemy_Move(ControlTestEnemy TestEnemy)
    {
        this.testenemy = TestEnemy;
    }

    public void Enter()
    {
        //���̓]���n�_��ݒu
        targetpos = testenemy.transform.position;

        if (testenemy.dir == 2)
        {
            targetpos.z += 30.0f;
        }
        if (testenemy.dir == 4)
        {
            targetpos.x -= 30.0f;
        }
        if (testenemy.dir == 6)
        {
            targetpos.x += 30.0f;
        }
        if (testenemy.dir == 8)
        {
            targetpos.z -= 30.0f;
        }

        //���̓]�����������߂�
        nextturn = Random.Range(1, 100);
    }

    public void Execute()
    {
        // ���W�ړ��v�Z
        testenemy.transform.Translate(testenemy.transform.right * testenemy.speed * Time.deltaTime, Space.World);

        //�y��ԑJ�ځz�]���n�_�ɒ�������Trun��Ԃ�
        if (Vector3.Distance(testenemy.transform.position, targetpos) <0.1f)
        {
            testenemy.transform.position = targetpos;
            if (nextturn <= 50)
            {
                testenemy.ChangeState(new TestEnemy_Trun(testenemy, true));
            }
            else 
            {
                testenemy.ChangeState(new TestEnemy_Trun(testenemy, false));
            }
        }
    }

    public void Exit()
    {

    }
}