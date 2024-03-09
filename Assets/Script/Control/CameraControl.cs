using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //ターゲット(Player)
    [SerializeField] public Transform Player;
    //カメラとの距離
    Vector3 distance;
    Vector3 distanceR;      //Playerが右向き
    Vector3 distanceL;      //Playerが左向き
    //目標値に到達するまでのおおよその時間[s]
    [SerializeField] public float SmoothTime = 0.3f;
    // 現在速度(SmoothDampの計算のために必要)
    Vector3 Velocity= Vector3.zero;

    void Start()
    {
        distance = transform.position - Player.transform.position;
        distanceR = distance;
        distanceL = distance;
        distanceL.x = distanceL.x * -1.0f;
    }
    void Update()
    {
        //Player向きを取得
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            distance = distanceR;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            distance = distanceL;
        }

        //目標位置取得
        Vector3 TargetPos = Player.transform.position + distance;

        //目的地に向かって時間の経過とともに徐々にベクトルを変化させます
        transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, SmoothTime);   
    }
}
