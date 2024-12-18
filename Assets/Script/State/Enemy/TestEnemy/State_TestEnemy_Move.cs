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
        //次の転向地点を設置
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

        //次の転向方向を決める
        nextturn = Random.Range(1, 100);

        if(testenemy.CheckisOutMap(targetpos)!=true)
        {
            nextturn = 1;
        }
    }

    public void Execute()
    {
        // 座標移動計算
        testenemy.transform.Translate(testenemy.transform.forward * testenemy.speed * Time.deltaTime, Space.World);

        //【状態遷移】転向地点に着いたらTrun状態に
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