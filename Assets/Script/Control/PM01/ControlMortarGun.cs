using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class ControlMortarGun : MonoBehaviour
{
    [Header("[vC[]")]
    public ControlPlayer player;

    [Header("[e]")]
    public GameObject mortar;

    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;
    [HideInInspector] private Quaternion localAngle;          // eΜό«
    [HideInInspector] private Vector3 firepos;                // eΆ¬Κu
    [HideInInspector] private Vector3 firedis_type1;          // eΆ¬ΚuΖΜ£
    [HideInInspector] private Vector3 firedis_type2;
    [HideInInspector] public float timer_nofire;              // itimerjΛΜΤ
    [HideInInspector] public float threshold_nofire;          // ΛΜΤΜθl(΅«’Ώ)
    [HideInInspector] public bool Mode;                       // 0;½Λ 1:C

    private IState currentState;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(new MortarGun_Up(this));

        firedis_type1 = new Vector3(-0.5f, 2.28f, 0);
        firedis_type2 = new Vector3(-0.8f, 2.95f, 0);

        threshold_nofire = 5.0f;
        timer_nofire = threshold_nofire;

        Mode = false;
    }

    void Update()
    {
        // »έΜXe[g
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

    public void SetMortar()
    {
        if (player.dir == 6)
        {
            firedis_type1.x *= -1f;
            firedis_type2.x *= -1f;
            localAngle.eulerAngles = new Vector3(13.0f, 0.0f, 0.0f);
        }
        else if (player.dir == 4)
        {
            firedis_type1.x *= -1f;
            firedis_type2.x *= -1f;
            localAngle.eulerAngles = new Vector3(13.0f, 180.0f, 0.0f);
        }

        if (Mode)
        {
            firepos = player.transform.position + firedis_type2;
        }
        else 
        {
            firepos = player.transform.position + firedis_type1;
        }
        
        GameObject newMortar = Instantiate(mortar, firepos, localAngle);
        newMortar.GetComponent<MortarControl>().dir = player.dir;
        newMortar.GetComponent<MortarControl>().Mode = Mode;

        player.ammomortar--;
    }
}