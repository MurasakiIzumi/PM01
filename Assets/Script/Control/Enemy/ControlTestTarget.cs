using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlTestTarget : MonoBehaviour
{
    public int hp;

    [Header("爆発")] public GameObject explosion;
    [Header("任務管理")] public MissionManager missionManager;

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
        missionManager.Targetnum++;
    }

    void Update()
    {
        // 現在のステート
        //currentState?.Execute();

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
            missionManager.Targetnum--;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= other.GetComponent<BulletControl>().damage;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Rocket")
        {
            hp -= other.GetComponent<RocketContrl>().damage;
            other.GetComponent<RocketContrl>().DestroySelf();
        }

        if (other.gameObject.tag == "Laser")
        {
            hp -= other.GetComponent<LaserControl>().damage;
        }

        if (other.gameObject.tag == "Destroy")
        {
            hp = -1;
        }
    }
}