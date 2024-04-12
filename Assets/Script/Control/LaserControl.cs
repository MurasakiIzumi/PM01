using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{
    public float speed;
    public int damage;

    [HideInInspector] Vector3 direction;                // 前進方向
    [HideInInspector] public float timer_live;         // （timer）存在時間
    [HideInInspector] public float threshold_live;    // 存在時間の閾値(しきいち)

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
        // 座標移動計算
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // タイマー更新
        timer_live += Time.deltaTime;

        // 存在時間を超えたら自滅
        if (timer_live > threshold_live)
        {
            Destroy(this.gameObject);
        }
    }
}
