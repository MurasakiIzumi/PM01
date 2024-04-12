using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlPlayer : MonoBehaviour
{
    //各部位
    [Header("[プレイヤーの各部位]")]
    public ControlBackArm part_backarm;
    public ControlBody part_body;
    public ControlFrontArm part_frontarm;
    public ControlLaserGun part_lasergun;
    public ControlLeg part_leg;
    public ControlRocketLancher part_rocketlancher;

    [HideInInspector] public int dir;                           // 向き（2上 4左 8下 6右）
    [HideInInspector] public bool flipx;

   //（!）Stateに関する変数はStateのScriptで管理しないように
   //【State】移動（Move）
   public float move_speed;                                    // 移動速度
    private IState currentState;

    private void Awake()
    {

    }

    void Start()
    {
        dir = 6;                    // 登場時の向き（右）
        flipx=false;
    }

    public void SetSpriteFlip(bool flip)
    {
        if (flip == true)
        {
            if (part_backarm && part_body && part_frontarm && part_lasergun && part_leg && part_rocketlancher)
            {
                part_backarm.spriteRenderer.flipX = true;
                part_body.spriteRenderer.flipX = true;
                part_frontarm.spriteRenderer.flipX = true;
                part_lasergun.spriteRenderer.flipX = true;
                part_leg.spriteRenderer.flipX = true;
                part_rocketlancher.spriteRenderer.flipX = true;
                flipx = true;

                this.GetComponent<BoxCollider>().center = ColliderFlip(this.GetComponent<BoxCollider>().center);

                //part_head.gameObject.GetComponent<BoxCollider>().center = ColliderFlip(part_head.gameObject.GetComponent<BoxCollider>().center);
                //part_hands.gameObject.GetComponent<BoxCollider>().center = ColliderFlip(part_hands.gameObject.GetComponent<BoxCollider>().center);
                //part_body.gameObject.GetComponent<BoxCollider>().center = ColliderFlip(part_body.gameObject.GetComponent<BoxCollider>().center);
                //part_leg2.gameObject.GetComponent<BoxCollider>().center = ColliderFlip(part_leg2.gameObject.GetComponent<BoxCollider>().center);
            }
            else
            {
                Debug.Log("各部位がちゃん設置されていない！");
            }
        }
        else if (flip == false)
        {
            if (part_backarm && part_body && part_frontarm && part_lasergun && part_leg && part_rocketlancher)
            {
                part_backarm.spriteRenderer.flipX = false;
                part_body.spriteRenderer.flipX = false;
                part_frontarm.spriteRenderer.flipX = false;
                part_lasergun.spriteRenderer.flipX = false;
                part_leg.spriteRenderer.flipX = false;
                part_rocketlancher.spriteRenderer.flipX = false;
                flipx = false;

                this.GetComponent<BoxCollider>().center = ColliderFlip(this.GetComponent<BoxCollider>().center);

                //part_head.gameObject.GetComponent<BoxCollider>().center = ColliderFlip(part_head.gameObject.GetComponent<BoxCollider>().center);
                //part_hands.gameObject.GetComponent<BoxCollider>().center = ColliderFlip(part_hands.gameObject.GetComponent<BoxCollider>().center);
                //part_body.gameObject.GetComponent<BoxCollider>().center = ColliderFlip(part_body.gameObject.GetComponent<BoxCollider>().center);
                //part_leg2.gameObject.GetComponent<BoxCollider>().center = ColliderFlip(part_leg2.gameObject.GetComponent<BoxCollider>().center);
            }
            else
            {
                Debug.Log("各部位がちゃん設置されていない！");
            }
        }
    }

    private Vector3 ColliderFlip(Vector3 vec)
    {
        Vector3 newvec = vec;
        newvec.x *= -1.0f;

        return newvec;
    }
}
