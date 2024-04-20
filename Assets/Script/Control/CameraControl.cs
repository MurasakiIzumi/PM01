using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //�^�[�Q�b�g(Player)
    [SerializeField] public GameObject Player;
    private Vector3 playerpos;

    //�J�����Ƃ̋���
    private Vector3 distance;
    private Vector3 distanceR;      //Player���E����
    private Vector3 distanceL;      //Player��������
    //�ڕW�l�ɓ��B����܂ł̂����悻�̎���[s]
    [SerializeField] public float SmoothTime = 0.3f;
    // ���ݑ��x(SmoothDamp�̌v�Z�̂��߂ɕK�v)
    private Vector3 Velocity = Vector3.zero;

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;

    private int nowpos;
    private bool OpenOver;

    void Start()
    {
        nowpos = 1;
        playerpos = Player.transform.position;
        distance = pos1 - playerpos;
        distanceR = distance;
        distanceL = distance;
        distanceL.x = distanceL.x * -1.0f;

    }
    void Update()
    {
        OpenOver = Player.GetComponent<ControlPlayer>().canRun;

        if (OpenOver)
        {
            //Player�������擾
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                distance = distanceR;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                distance = distanceL;
            }
        }

        //�ڕW�ʒu�擾
        Vector3 TargetPos = Player.transform.position + distance;

        if (OpenOver)
        {
            //�ړI�n�Ɍ������Ď��Ԃ̌o�߂ƂƂ��ɏ��X�Ƀx�N�g����ω������܂�
            transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, SmoothTime);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, TargetPos, ref Velocity, SmoothTime / 3);
        }

        if (OpenOver)
        {
            //�}�I�X�̃X�N���[���ŃJ����������ύX
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                CameraPosChange(Input.GetAxis("Mouse ScrollWheel"), TargetPos);
            }
        }
    }

    void CameraPosChange(float input, Vector3 target)
    {
        Vector3 pos = target;

        if (input>0.0f)
        {
            nowpos--;
            pos = new Vector3(pos.x / 1.5f, pos.y / 1.5f, pos.z / 1.5f);
        }
        else if(input<0.0f)
        {
            nowpos++;
            pos = new Vector3(pos.x * 1.5f, pos.y * 1.5f, pos.z * 1.5f);
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
                distance = pos1 - playerpos;
                break;
            case 2:
                distance = pos2 - playerpos;
                break;
            case 3:
                distance = pos3 - playerpos;
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
