using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public int Targetnum;

    [Header("�v���C���[")] public GameObject Player;
    [Header("UI�Ǘ�")] public UIManager UImanager;
    [Header("���E���C��")] public GameObject Evacuate;
    [Header("�^�C�}�[")] public Timer timer;
    [Header("��펞��")] public int TotalTime;
    [HideInInspector] public bool CanMove;
    [HideInInspector] public bool isMissionComplete;
    [HideInInspector] public bool isTimeOut;

    void Start()
    {
        timer.TotalTime= TotalTime;
        CanMove = false;
        isMissionComplete = false;
        isTimeOut=false;
    }


    void Update()
    {
        CheckCanStart();

        CheckMission();

        if (UImanager.UImid)
        {
            timer.isRunning = true;
            Player.GetComponent<ControlPlayer>().HpRun = true;
        }

        if (isMissionComplete)
        {
            ShowEvacuateLine();
            EvacuatePlayer();
        }
        else if (timer.isTimeOut)
        {
            UImanager.isTimeOut = true;
            ShowEvacuateLine();
            EvacuatePlayer();
        }
        else 
        {
            CheckPlayerPos();
        }
    }

    private void CheckCanStart()
    {
        if(Player.GetComponent<ControlPlayer>().canRun)
        {
            if (CanMove != true)
            {
                StartCoroutine("UIStart");
            }
        }

    }

    private void CheckMission()
    {
        if (Targetnum <= 0)
        {
            isMissionComplete = true;
            UImanager.isMissionComplete = true;
        }
    }

    private void ShowEvacuateLine()
    {
        Evacuate.SetActive(true);
    }

    private void CheckPlayerPos()
    {
        Vector3 playerpos = Player.transform.position;

        if ((playerpos.x > 88.0f) || (playerpos.x < -88.0f) || (playerpos.z > 88.0f) || (playerpos.z < -88.0f))
        {
            playerpos.x = Mathf.Max(-89.0f, Mathf.Min(Player.transform.position.x, 89.0f));
            playerpos.z = Mathf.Max(-89.0f, Mathf.Min(Player.transform.position.z, 89.0f));
            Player.transform.position = playerpos;
        }
    }

    private void EvacuatePlayer()
    {
        if (Player.transform.position.x >= 90.0f)
        {
            SceneManager.LoadScene("StageSelect");
        }

        if (Player.transform.position.x <= -90.0f)
        {
            SceneManager.LoadScene("StageSelect");
        }

        if (Player.transform.position.z >= 90.0f)
        {
            SceneManager.LoadScene("StageSelect");
        }

        if (Player.transform.position.z <= -90.0f)
        {
            SceneManager.LoadScene("StageSelect");
        }
    }

    IEnumerator UIStart()
    {
        yield return new WaitForSeconds(0.5f);
        //�x�点��������
        UImanager.UIstart = true;
        CanMove = true;
    }
}
