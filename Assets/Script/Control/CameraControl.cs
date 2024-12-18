using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    //ターゲット(Player)
    [SerializeField] public GameObject Player;

    //カメラとの距離
    private Vector3 distance;
    private Vector3 distanceR;      //Playerが右向き
    private Vector3 distanceL;      //Playerが左向き
    //目標値に到達するまでのおおよその時間[s]
    [SerializeField] public float SmoothTime = 0.3f;
    // 現在速度(SmoothDampの計算のために必要)
    private Vector3 Velocity = Vector3.zero;

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;

    private int nowpos;
    private bool OpenOver;

    private Quaternion OriginRotation;

    void Start()
    {
        nowpos = 2;
        distance = pos1;
        distanceR = distance;
        distanceL = distance;
        distanceL.x = distanceL.x * -1.0f;

        OriginRotation = transform.rotation;
        transform.rotation = Quaternion.LookRotation(Player.transform.position - transform.position);

    }
    void Update()
    {
        if (OpenOver!= Player.GetComponent<ControlPlayer>().canRun)
        {
            OpenOver = Player.GetComponent<ControlPlayer>().canRun;
            distance = pos2;
            distanceR = distance;
            distanceL = distance;
            distanceL.x = distanceL.x * -1.0f;
        }
        
        if (OpenOver)
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
        }

        //目標位置取得
        Vector3 TargetPos = Player.transform.position + distance;

        if (OpenOver)
        {
            //目的地に向かって時間の経過とともに徐々にベクトルを変化させます
            transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, SmoothTime);

            if (transform.rotation != OriginRotation)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, OriginRotation, 5.0f * Time.deltaTime);
            }
        }
        else 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.transform.position - transform.position), 10.0f * Time.deltaTime);
        }

        if (OpenOver)
        {
            //マオスのスクロールでカメラ距離を変更
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                CameraPosChange(Input.GetAxis("Mouse ScrollWheel"));
            }
        }
    }

    void CameraPosChange(float input)
    {
        if (input>0.0f)
        {
            nowpos--;
        }
        else if(input<0.0f)
        {
            nowpos++;
        }

        if (nowpos > 3)
        {
            nowpos = 3;
            return;
        }
        else if(nowpos<1)
        {
            nowpos = 1;
            return;
        }

        switch (nowpos)
        {
            case 1:
                distance = pos1;
                break;
            case 2:
                distance = pos2;
                break;
            case 3:
                distance = pos3;
                break;
        }

        distanceR = distance;
        distanceL = distance;
        distanceL.x = distanceL.x * -1.0f;

        if (Player.GetComponent<ControlPlayer>().flipx == false)
        {
            distance = distanceR;
        }
        else
        {
            distance = distanceL;
        }

        transform.position = Vector3.Lerp(transform.position, Player.transform.position + distance, 1.0f);

    }
}
