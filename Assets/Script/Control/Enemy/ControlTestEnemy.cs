using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlTestEnemy : MonoBehaviour
{
    public int hp;
    public float speed;
    public float rotspd;

    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;
    [HideInInspector] public int dir;    // �����i2�� 4�� 8�� 6�E�j

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(new TestEnemy_Idle(this));

        dir = 6;
    }

    void Update()
    {
        // ���݂̃X�e�[�g
        currentState?.Execute();

        HPCheck();
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

    public void HPCheck()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp--;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Laser")
        {
            hp = 0;
        }
    }

}