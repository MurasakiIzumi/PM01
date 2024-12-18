using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControl : MonoBehaviour
{
    public bool haveDamage = false;
    [HideInInspector] public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        // アニメーションプレイ状態を取得
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (haveDamage)
        {
            if (state.normalizedTime >= 0.7f)
            {
                GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        // アニメーションが終わったら消滅
        if (state.normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
