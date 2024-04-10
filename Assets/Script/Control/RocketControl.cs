using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class RocketContrl : MonoBehaviour
{
    public float speed;

    [Header("爆発")] public GameObject explosion;

    [HideInInspector] public Vector3 direction;                // 前進方向
    [HideInInspector] public GameObject target;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;

    private IState currentState;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        if (transform.rotation.z == 0)
        {
            speed *= 1.0f;
        }
        else
        {
            speed *= -1.0f;
        }

        ChangeState(new Rocket_Idle(this));
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

    public void DestroySelf()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = other.gameObject;
            this.GetComponent<BoxCollider>().enabled = false;
            ChangeState(new Rocket_Attack(this));
        }
    }


}
