using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControl : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // �A�j���[�V�����v���C��Ԃ��擾
        var state = animator.GetCurrentAnimatorStateInfo(0);

        // �A�j���[�V�������I����������
        if (state.normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
