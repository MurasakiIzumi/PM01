using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image UIbg;
    public GameObject MiniMap;
    public GameObject Hp;
    public GameObject Power;
    public GameObject Ammo;
    public Image Timer;
    public GameObject TimerText;
    public GameObject MissionHint;
    public GameObject MissionCompleteHint;
    public GameObject TimeOutdHint;

    [HideInInspector] public bool UIstart;
    [HideInInspector] public bool UImid;
    [HideInInspector] public bool UIend;
    [HideInInspector] public bool isMissionComplete;
    [HideInInspector] public bool isTimeOut;

    private float timer;

    void Start()
    {
        UIstart = false;
        UImid = false;
        UIend = false;
        timer = 0;
        isMissionComplete=false;
        isTimeOut=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UIstart)
        {
            StartCoroutine("MissionHintStart");

            UIbg.fillAmount += Time.deltaTime * 1.5f;

            Timer.fillAmount += Time.deltaTime * 1.5f;

            if (UIbg.fillAmount >= 1.0f)
            {
                UImid = true;
                UIstart = false;
            }
        }

        if (UImid)
        {
            MiniMap.SetActive(true);
            Hp.SetActive(true);
            Power.SetActive(true);
            Ammo.SetActive(true);
            TimerText.SetActive(true);

            UIend = true;
        }

        if (UIend)
        {
            if (Hp.GetComponent<Image>().fillAmount >= 1.0f)
            {
                MissionHint.SetActive(false);
                UIend = false;
            }
        }

        if (isMissionComplete)
        {
            timer += Time.deltaTime;

            if (timer >= 2.0f)
            {
                MissionCompleteHint.SetActive(false);
                timer = 0;
            }
            else if (timer >= 1.0f)
            {
                MissionCompleteHint.SetActive(true);
            }
        }
        else if (isTimeOut)
        {
            timer += Time.deltaTime;

            if (timer >= 1.0f)
            {
                TimeOutdHint.SetActive(false);
                timer = 0;
            }
            else if (timer >= 0.5f)
            {
                TimeOutdHint.SetActive(true);
            }
        }
    }

    IEnumerator MissionHintStart()
    {
        yield return new WaitForSeconds(1.0f);
        //íxÇÁÇπÇΩÇ¢èàóù
        if (MissionHint.activeSelf)
        {
            yield break;
        }

        MissionHint.SetActive(true);
    }
}
