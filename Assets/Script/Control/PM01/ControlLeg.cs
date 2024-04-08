using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlLeg : MonoBehaviour
{
    [Header("[�v���C���[]")]
    public ControlPlayer player;

    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;

    [HideInInspector] public float timer_noInput;            // �itimer�j���͂��Ă��Ȃ�����
    [HideInInspector] public float threshold_noInput;        // ���͂��Ă��Ȃ����Ԃ�臒l(��������)

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(new Leg_Idle(this));

        timer_noInput = 0;
        threshold_noInput = 0.1f;
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

}