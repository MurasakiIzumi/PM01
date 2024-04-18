using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Body_Jump : IState
{
    private ControlBody body;
    private float Jumpspeed;
    private Vector3 target;
    private float timer;

    public Body_Jump(ControlBody Body)
    {
        this.body = Body;
    }

    public void Enter()
    {
        body.SetAnimation("Jump");
        body.player.isJump = true;
        Jumpspeed = body.player.move_speed;
        timer = 0;
        body.player.Power -= 70.0f;
    }
    public void Execute()
    {
        //座標計算
        body.player.transform.Translate(Vector3.up * Jumpspeed * Time.deltaTime, Space.World);

        //上昇と伴いスピードダウン
        if (timer >= 0.5f)
        {
            timer = 0;
            Jumpspeed *= 0.8f;
        }
        else
        {
            timer += Time.deltaTime;
        }
        
        //目標座標を更新
        target = new Vector3(body.player.transform.position.x, body.player.jumphigh, body.player.transform.position.z);

        if ((Vector3.Distance(body.player.transform.position, target) < 0.1f))
        {
            body.player.transform.position = target;

            //【状態遷移】Fall状態に
            body.ChangeState(new Body_Fall(body,Jumpspeed));
        }

        //煙幕生成
        if (body.timer_smoke >= body.time_setsmoke)
        {
            body.SetSmoke();
            body.timer_smoke = 0;
        }
        else
        {
            body.timer_smoke += Time.deltaTime;
        }
    }
    public void Exit()
    {

    }
}