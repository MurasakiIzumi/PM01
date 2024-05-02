using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlBeaconLancher : MonoBehaviour
{
    [Header("[�v���C���[]")]
    public ControlPlayer player;

    [Header("[�r�[�R��]")]
    public GameObject beacon;

    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;
    [HideInInspector] private Vector3 localAngle;            // �e�̌���
    [HideInInspector] private Vector3 firepos;               // �e�����ʒu
    [HideInInspector] private Vector3 firedis;               // �e�����ʒu�Ƃ̋���
    [HideInInspector] public bool isfired;
    [HideInInspector] public float timer_nofire;             // �itimer�j�ˌ��̊�
    [HideInInspector] public float threshold_nofire;         // �ˌ��̊Ԃ�臒l(��������)

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(new BeaconLancher_Up(this));

        firedis = new Vector3(-2f, 2.8f, 0);
        isfired = false;
        timer_nofire = 0;
        threshold_nofire = 10.0f;
    }

    void Update()
    {
        // ���݂̃X�e�[�g
        if (player.canRun)
        {
            currentState?.Execute();
        }
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

    public void SetBeacon()
    {
        if (player.dir == 6)
        {
            firedis.x = -2f;
            localAngle = new Vector3(13.0f, 0.0f, 0.0f);
        }
        else if (player.dir == 4)
        {
            firedis.x = 2f;
            localAngle = new Vector3(13.0f, 0.0f, 180.0f);
        }

        firepos = player.transform.position + firedis;

        Instantiate(beacon, firepos, Quaternion.Euler(localAngle));

        
    }
}