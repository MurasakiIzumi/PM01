using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlBody : MonoBehaviour
{
    [Header("[プレイヤー]")]
    public ControlPlayer player;

    [Header("煙幕")] public GameObject smoke;
    [Header("落下攻撃判定")] public GameObject FallAttack;

    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;

    [HideInInspector] public float timer_noInput;            // （timer）入力していない時間
    [HideInInspector] public float threshold_noInput;        // 入力していない時間の閾値(しきいち)
    [HideInInspector] public bool isfired;
    [HideInInspector] public float timer_nofire;             // （timer）射撃の間
    [HideInInspector] public float threshold_nofire;         // 射撃の間の閾値(しきいち)
    [HideInInspector] private Vector3 firepos;                       // 煙幕生成位置
    [HideInInspector] private Vector3 firedis1;                       // 煙幕生成位置との距離1
    [HideInInspector] private Vector3 firedis2;                       // 煙幕生成位置との距離2
    [HideInInspector] private Vector3 firedis3;                       // 煙幕生成位置との距離3
    [HideInInspector] public float timer_smoke;
    [HideInInspector] public float time_setsmoke;

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(new Body_Idle(this));

        timer_noInput = 0;
        threshold_noInput = 0.1f;
        isfired = false;
        timer_nofire = 0;
        threshold_nofire = 3.0f;

        firedis1 = new Vector3(-1.2f, -0.4f, -0.4f);
        firedis2 = new Vector3(-0.65f, -0.4f, 0);
        firedis3 = new Vector3(0.65f, -0.4f, 0);

        timer_smoke = 0;
        time_setsmoke = 0.08f;
    }

    void Update()
    {
        // 現在のステート
        currentState?.Execute();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public bool AnimationFinished(string animationName)
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    }

    public void SetSmoke()
    {
        if (player.dir == 6)
        {
            firedis1.x = -1.2f;
        }
        else if (player.dir == 4)
        {
            firedis1.x = 1.2f;
        }

        firepos = player.transform.position + firedis1;

        Instantiate(smoke, firepos, Quaternion.identity);

        firepos = player.transform.position + firedis2;

        Instantiate(smoke, firepos, Quaternion.identity);

        firepos = player.transform.position + firedis3;

        Instantiate(smoke, firepos, Quaternion.identity);
    }
}