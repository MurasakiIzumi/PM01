using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TestEnemy_Idle : IState
{
    private ControlTestEnemy testenemy;

    public TestEnemy_Idle(ControlTestEnemy TestEnemy)
    {
        this.testenemy = TestEnemy;
    }

    public void Enter()
    {

    }

    public void Execute()
    {
        testenemy.ChangeState(new TestEnemy_Move(testenemy));
    }

    public void Exit()
    {

    }
}