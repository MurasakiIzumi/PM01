using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MissionManager : MonoBehaviour
{
    public int Targetnum;

    [Header("vC[")] public GameObject Player;
    [Header("UIÇ")] public UIManager UImanager;
    [Header("£EC")] public GameObject Evacuate;
    [Header("^C}[")] public Timer timer;
    [Header("ìíÔ")] public int TotalTime;
    [Header("O¹C")] public GameObject KineticObj;
    [HideInInspector] public bool CanMove;
    [HideInInspector] public bool isMissionComplete;
    [HideInInspector] public bool isTimeOut;

    private float timer_Kinetic;
    private float Relord_Kinetic;

    void Start()
    {
        timer.TotalTime= TotalTime;
        CanMove = false;
        isMissionComplete = false;
        isTimeOut=false;

        timer_Kinetic=0;
        Relord_Kinetic = 2.0f;
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

        if (UImanager.isTimeOut)
        {
            timer_Kinetic += Time.deltaTime;

            if (timer_Kinetic >= Relord_Kinetic)
            {
                KineticAttack();
                timer_Kinetic = 0;
                Relord_Kinetic = Random.Range(0.25f, 0.5f);
            }
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

    private void KineticAttack()
    {
        Vector3 TargetPos=new Vector3(Random.Range(-85.0f, 85.0f),60.0f, Random.Range(-85.0f, 85.0f));

        Instantiate(KineticObj, TargetPos, Quaternion.identity);
    }

    IEnumerator UIStart()
    {
        yield return new WaitForSeconds(0.5f);
        //xç¹½¢
        UImanager.UIstart = true;
        CanMove = true;
    }
}
