using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    public float speed;
    public int damage;

    [HideInInspector] private float timer_live;         // �itimer�j���ݎ���
    [HideInInspector] private float threshold_live;    // ���ݎ��Ԃ�臒l(��������)
    //[HideInInspector] private float rand;

    void Start()
    {
        timer_live = 0;
        threshold_live = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // ���W�ړ��v�Z
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        // �^�C�}�[�X�V
        timer_live += Time.deltaTime;

        // ���ݎ��Ԃ𒴂����玩��
        if (timer_live > threshold_live)
        {
            Destroy(this.gameObject);
        }
    }
}
