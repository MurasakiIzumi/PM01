using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class MissionManager : MonoBehaviour
{
    public int Targetnum;

    [Header("ÉvÉåÉCÉÑÅ[")] public GameObject Player;
    [Header("UIä«óù")] public UIManager UImanager;
    [Header("ó£íEÉâÉCÉì")] public GameObject Evacuate;
    [Header("É^ÉCÉ}Å[")] public Timer timer;
    [Header("çÏêÌéûä‘")] public int TotalTime;
    [Header("ãOìπñCåÇ")] public GameObject KineticObj;
    [Header("îöî≠")] public GameObject Explosion;
    [HideInInspector] public bool CanMove;
    [HideInInspector] public bool isMissionComplete;
    [HideInInspector] public bool isTimeOut;
    [HideInInspector] public int whatStage;

    private float timer_Kinetic;
    private float Relord_Kinetic;

    private void Awake()
    {
        Pm01DataLoad();
    }
    void Start()
    {
        Targetnum = 0;
        timer.TotalTime= TotalTime;
        CanMove = false;
        isMissionComplete = false;
        isTimeOut=false;

        timer_Kinetic=0;
        Relord_Kinetic = 2.0f;

        Scene scene;
        scene = SceneManager.GetActiveScene();

        whatStage = scene.buildIndex - 1;
    }


    void Update()
    {
        CheckCanStart();

        CheckMission();

        CheckPlayerHp();

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

    private void CheckPlayerHp()
    {
        if (Player.GetComponent<ControlPlayer>().isstart != true)
        {
            if (Player.GetComponent<ControlPlayer>().Hp <= 0.0f)
            {
                Player.GetComponent<ControlPlayer>().Hp = 100.0f;
                Player.SetActive(false);
                Instantiate(Explosion, Player.transform.position, Quaternion.identity);
                StartCoroutine("GameOver");
            }
        }
    }

    private void CheckMission()
    {
        if (CanMove)
        {
            if (Targetnum <= 0)
            {
                isMissionComplete = true;
                UImanager.isMissionComplete = true;
            }
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

    private void Pm01DataLoad()
    {
        GameObject Messager = GameObject.Find("DataMessager");

        if (!Messager)
        {
            return;
        }

        DataMessager data = Messager.GetComponent<DataMessager>();
        ControlPlayer player=Player.GetComponent<ControlPlayer>();

        player.ArmR = data.Arm1;
        player.ArmL = data.Arm2;
        player.shoulderR = data.Shoulder1;
        player.shoulderL = data.Shoulder2;

    }


    IEnumerator UIStart()
    {
        yield return new WaitForSeconds(0.5f);
        //íxÇÁÇπÇΩÇ¢èàóù
        UImanager.UIstart = true;
        CanMove = true;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.0f);

        //íxÇÁÇπÇΩÇ¢èàóù
        SceneManager.LoadScene("StageSelect");
    }
}
