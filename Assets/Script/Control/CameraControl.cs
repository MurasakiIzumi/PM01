using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //ターゲット(Player)
    [SerializeField] public Transform Player;
    //カメラとの距離
    Vector3 distance;
    //目標値に到達するまでのおおよその時間[s]
    [SerializeField] public float SmoothTime = 0.3f;
    // 現在速度(SmoothDampの計算のために必要)
    Vector3 Velocity= Vector3.zero;

    void Start()
    {
        distance = transform.position - Player.position;
    }
    void Update()
    {
        //現在位置取得
        Vector3 TargetPos = Player.position + distance;

        //目的地に向かって時間の経過とともに徐々にベクトルを変化させます
        transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, SmoothTime);   
    }
}
