using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //�^�[�Q�b�g(Player)
    [SerializeField] public Transform Player;
    //�J�����Ƃ̋���
    Vector3 distance;
    //�ڕW�l�ɓ��B����܂ł̂����悻�̎���[s]
    [SerializeField] public float SmoothTime = 0.3f;
    // ���ݑ��x(SmoothDamp�̌v�Z�̂��߂ɕK�v)
    Vector3 Velocity= Vector3.zero;

    void Start()
    {
        distance = transform.position - Player.position;
    }
    void Update()
    {
        //���݈ʒu�擾
        Vector3 TargetPos = Player.position + distance;

        //�ړI�n�Ɍ������Ď��Ԃ̌o�߂ƂƂ��ɏ��X�Ƀx�N�g����ω������܂�
        transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, SmoothTime);   
    }
}
