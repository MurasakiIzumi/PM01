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
        // �A�j���[�V�����v���C��Ԃ��擾
        var state = animator.GetCurrentAnimatorStateInfo(0);

        // �A�j���[�V�������I����������
        if (state.normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
