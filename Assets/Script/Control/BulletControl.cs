using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed;
    public int damage;

    [HideInInspector] private Vector3 direction;                // �O�i����
    [HideInInspector] private float timer_live;         // �itimer�j���ݎ���
    [HideInInspector] private float threshold_live;    // ���ݎ��Ԃ�臒l(��������)
    [HideInInspector] private float rand;

    void Start()
    {
        timer_live = 0;
        threshold_live = 3.0f;
        rand = Random.Range(-0.05f, 0.05f);
        direction = new Vector3(1.0f, rand, 0);

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
        transform.Translate(direction * speed * Time.deltaTime,Space.World);

        // �^�C�}�[�X�V
        timer_live += Time.deltaTime;

        // ���ݎ��Ԃ𒴂����玩��
        if (timer_live > threshold_live)
        {
            Destroy(this.gameObject);
        }
    }
}
