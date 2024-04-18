using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlBody : MonoBehaviour
{
    [Header("[�v���C���[]")]
    public ControlPlayer player;

    [Header("����")] public GameObject smoke;
    [Header("�����U������")] public GameObject FallAttack;

    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;

    [HideInInspector] public float timer_noInput;            // �itimer�j���͂��Ă��Ȃ�����
    [HideInInspector] public float threshold_noInput;        // ���͂��Ă��Ȃ����Ԃ�臒l(��������)
    [HideInInspector] public bool isfired;
    [HideInInspector] public float timer_nofire;             // �itimer�j�ˌ��̊�
    [HideInInspector] public float threshold_nofire;         // �ˌ��̊Ԃ�臒l(��������)
    [HideInInspector] private Vector3 firepos;                       // ���������ʒu
    [HideInInspector] private Vector3 firedis1;                       // ���������ʒu�Ƃ̋���1
    [HideInInspector] private Vector3 firedis2;                       // ���������ʒu�Ƃ̋���2
    [HideInInspector] private Vector3 firedis3;                       // ���������ʒu�Ƃ̋���3
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
        // ���݂̃X�e�[�g
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