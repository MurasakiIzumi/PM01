using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TestEnemy_Trun : IState
{
    private ControlTestEnemy testenemy;
    private float targetAngle;
    private bool isright;
    private int nextdir;
    private float angle;

    public TestEnemy_Trun(ControlTestEnemy TestEnemy,bool isRight)
    {
        this.testenemy = TestEnemy;
        this.isright = isRight;

    }

    public void Enter()
    {
        //“]ŒüŠp“x‚ğŒˆ‚ß‚é
        if (isright)
        {
            if (testenemy.dir == 2)
            {
                targetAngle = 0.0f;
                angle = -90.0f;
                nextdir = 6;
            }
            if (testenemy.dir == 4)
            {
                targetAngle = 270.0f;
                angle = 180.0f;
                nextdir = 2;
            }
            if (testenemy.dir == 6)
            {
                targetAngle = 90.0f;
                angle = 0.0f;
                nextdir = 8;
            }
            if (testenemy.dir == 8)
            {
                targetAngle = 180.0f;
                angle = 90.0f;
                nextdir = 4;
            }
        }
        else
        {
            if (testenemy.dir == 2)
            {
                targetAngle = 180.0f;
                angle = 270.0f;
                nextdir = 4;
            }
            if (testenemy.dir == 4)
            {
                targetAngle = 90.0f;
                angle = 180.0f;
                nextdir = 8;
            }
            if (testenemy.dir == 6)
            {
                targetAngle = -90.0f;
                angle = 0.0f;
                nextdir = 2;
            }
            if (testenemy.dir == 8)
            {
                targetAngle = 0.0f;
                angle = 90.0f;
                nextdir = 6;
            }
        }
    }

    public void Execute()
    {
        //“]ŒüŒvZ
        if (isright)
        {
            angle += testenemy.rotspd * Time.deltaTime;
        }
        else 
        {
            angle -= testenemy.rotspd * Time.deltaTime;
        }

        testenemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        //yó‘Ô‘JˆÚz“]Œü–Ú•W‚ª“Í‚¯‚½‚çMoveó‘Ô‚É
        if (isright)
        {
            if ((targetAngle - angle) < 0.1f)
            {
                angle = targetAngle;
                testenemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                testenemy.dir = nextdir;
                testenemy.ChangeState(new TestEnemy_Move(testenemy));
            }
        }
        else
        {
            if ((targetAngle - angle) > -0.1f)
            {
                angle = targetAngle;
                testenemy.transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                testenemy.dir = nextdir;
                testenemy.ChangeState(new TestEnemy_Move(testenemy));
            }
        }
    }

    public void Exit()
    {

    }
}