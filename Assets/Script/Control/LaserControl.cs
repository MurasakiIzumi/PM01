using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public float speed;
    public int damage;

    [HideInInspector] Vector3 direction;                // �O�i����
    [HideInInspector] public float timer_live;         // �itimer�j���ݎ���
    [HideInInspector] public float threshold_live;    // ���ݎ��Ԃ�臒l(��������)

    void Start()
    {
        timer_live = 0;
        threshold_live = 2.0f;
        direction = new Vector3(1.0f, 0, 0);

        if (transform.rotation.z == 0)
        {
            speed *= 1.0f;
        }
        else
        {
            speed *= -1.0f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // ���W�ړ��v�Z
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // �^�C�}�[�X�V
        timer_live += Time.deltaTime;

        // ���ݎ��Ԃ𒴂����玩��
        if (timer_live > threshold_live)
        {
            Destroy(this.gameObject);
        }
    }
}
