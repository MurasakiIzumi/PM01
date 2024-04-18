using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeControl : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        transform.localEulerAngles = new Vector3(13.0f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // アニメーションプレイ状態を取得
        var state = animator.GetCurrentAnimatorStateInfo(0);

        // アニメーションが終わったら消滅
        if (state.normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
