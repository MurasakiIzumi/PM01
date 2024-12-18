using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonControl : MonoBehaviour
{
    public float speed;
    public int damage;

    [Header("命中")] public GameObject Explosion;

    [HideInInspector] private float timer_live;         // （timer）存在時間
    [HideInInspector] private float threshold_live;    // 存在時間の閾値(しきいち)

    void Start()
    {
        timer_live = 0;
        threshold_live = 4.0f;
    }

    void Update()
    {
        // 座標移動計算
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

        // タイマー更新
        timer_live += Time.deltaTime;

        // 存在時間を超えたら自滅
        if (timer_live > threshold_live)
        {
            Destroy(this.gameObject);
        }
    }
    public void Hit()
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
