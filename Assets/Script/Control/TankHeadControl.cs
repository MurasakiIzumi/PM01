using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadControl : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject cannonball;
    public GameObject Cannnon;
    public GameObject Gun;
    public float rotationspeed;
    public float searchdis;
    public float attackdis;

    private Vector3 ZreoY;
    private Vector3 target;
    private float timer_nofire;             // �itimer�j�ˌ��̊�
    private int threshold_fire;           // �A�˂�臒l
    private float threshold_nofire;         // �ˌ��̊Ԃ�臒l
    private float threshold_relord;

    private float timer_cannon;             // �itimer�j�ˌ��̊�
    private float threshold_cannon;         // �ˌ��̊Ԃ�臒l

    // Start is called before the first frame update
    void Start()
    {
        ZreoY = this.transform.position;
        target = new Vector3(0, 0, 0);
        timer_nofire = 0;
        threshold_fire = 0;
        threshold_nofire = 0.1f;
        threshold_relord = -2.0f;

        timer_cannon = 0;
        threshold_cannon = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Player���W�擾
        target = player.transform.position;
        target.y = ZreoY.y;

        //Player���T�[�`�͈͓��Ȃ�_��
        if (Vector3.Distance(this.transform.position, player.transform.position) < searchdis)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(target - this.transform.position), rotationspeed * Time.deltaTime);
        }

        //Player���U���͈͓��Ȃ�U��
        if (Vector3.Distance(this.transform.position, player.transform.position) < attackdis)
        {
            timer_nofire += Time.deltaTime;
            timer_cannon +=Time.deltaTime;

            if (timer_nofire >= threshold_nofire)
            {
                SetBullet();
            }

            if (threshold_fire > 3)
            {
                threshold_fire = 0;
                timer_nofire = threshold_relord;
            }

            if (timer_cannon >= threshold_cannon)
            {
                SetCannon();
            }
        }
        else
        {
            timer_nofire = 0;
        }
    }
    private void SetBullet()
    {
        Instantiate(bullet, Gun.transform.position, transform.rotation);
        threshold_fire++;
        timer_nofire = 0;
    }

    private void SetCannon()
    {
        Instantiate(cannonball, Cannnon.transform.position, transform.rotation);
        timer_cannon = 0;
    }
}
