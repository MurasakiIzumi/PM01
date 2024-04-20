using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public int Targetnum;

    [Header("プレイヤー")] public GameObject Player;
    [Header("UI管理")] public UIManager UImanager;
    [Header("離脱ライン")] public GameObject Evacuate;
    [Header("タイマー")] public Timer timer;
    [Header("作戦時間")] public int TotalTime;
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

        if (timer.isTimeOut)
        {
            UImanager.isTimeOut = true;
            ShowEvacuateLine();
            EvacuatePlayer();
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

        if (Player.transform.position.y >= 90.0f)
        {
            SceneManager.LoadScene("StageSelect");
        }

        if (Player.transform.position.y <= -90.0f)
        {
            SceneManager.LoadScene("StageSelect");
        }
    }

    IEnumerator UIStart()
    {
        yield return new WaitForSeconds(0.5f);
        //遅らせたい処理
        UImanager.UIstart = true;
        CanMove = true;
    }
}
