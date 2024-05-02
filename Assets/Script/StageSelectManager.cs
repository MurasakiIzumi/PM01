using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class StageSelectManager : MonoBehaviour
{
    [Header("選択ボタン")]
    public GameObject StageButton;

    [Header("整備画面")]
    public GameObject Pm01;
    public GameObject Weapon;
    public GameObject StartButton;

    public Image image_Arm1;
    public Image image_Arm2;
    public Image image_Shoulder1;
    public Image image_Shoulder2;

    public Text text_Arm1;
    public Text text_Arm2;
    public Text text_Shoulder1;
    public Text text_Shoulder2;

    [Header("パーツ")]
    public Sprite Null;
    public Sprite ArmR1;
    public Sprite ArmL1;
    public Sprite ShoulderR1;
    public Sprite ShoulderR2;
    public Sprite ShoulderL1;
    public Sprite ShoulderL2;

    [Header("メッセンジャー")]
    public DataMessager Messager;

    [HideInInspector] public int Stage;
    [HideInInspector] public int Arm1 = 1;
    [HideInInspector] public int Arm2 = 1;
    [HideInInspector] public int Shoulder1 = 1;
    [HideInInspector] public int Shoulder2 = 1;

    void Start()
    {
        Stage = 0;
        Pm01DataLoad();
    }

    void Update()
    {
        Pm01ImageCheck();
        Pm01TextCheck();
        Pm01DataSave();
    }

    public void StageSelecet(int num)
    {
        Stage = num;

        StageButton.SetActive(false);
        Pm01.SetActive(true);
        Weapon.SetActive(true);
        StartButton.SetActive(true);
    }

    private void Pm01ImageCheck()
    {
        switch (Arm1)
        {
            case 0:
                image_Arm1.sprite = Null;
                break;
            case 1:
                image_Arm1.sprite = ArmR1;
                break;
        }

        switch (Arm2)
        {
            case 0:
                image_Arm2.sprite = Null;
                break;
            case 1:
                image_Arm2.sprite = ArmL1;
                break;
        }

        switch (Shoulder1)
        {
            case 0:
                image_Shoulder1.sprite = Null;
                break;
            case 1:
                image_Shoulder1.sprite = ShoulderR1;
                image_Shoulder1.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 2:
                image_Shoulder1.sprite = ShoulderR2;
                image_Shoulder1.gameObject.transform.localScale = new Vector3(2f, 2f, 1f);
                break;

        }

        switch (Shoulder2)
        {
            case 0:
                image_Shoulder2.sprite = Null;
                break;
            case 1:
                image_Shoulder2.sprite = ShoulderL1;
                image_Shoulder2.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case 2:
                image_Shoulder2.sprite = ShoulderL2;
                image_Shoulder2.gameObject.transform.localScale = new Vector3(2f, 2f, 1f);
                break;

        }
    }

    private void Pm01TextCheck()
    {
        switch (Arm1)
        {
            case 0:
                text_Arm1.text = "無";
                break;
            case 1:
                text_Arm1.text = ".50 機関銃";
                break;
        }

        switch (Arm2)
        {
            case 0:
                text_Arm2.text = "無";
                break;
            case 1:
                text_Arm2.text = ".50 機関銃";
                break;
        }

        switch (Shoulder1)
        {
            case 0:
                text_Shoulder1.text = "無";
                break;
            case 1:
                text_Shoulder1.text = "三連装ミサイルランチャー";
                break;
            case 2:
                text_Shoulder1.text = "VT/HE　両用迫撃砲";
                break;

        }

        switch (Shoulder2)
        {
            case 0:
                text_Shoulder2.text = "無";
                break;
            case 1:
                text_Shoulder2.text = "エナジーライフル砲";
                break;
            case 2:
                text_Shoulder2.text = "砲撃支援ユニット";
                break;

        }
    }

    private void Pm01DataSave()
    {
        if (!Messager)
        {
            return;
        }

        Messager.Arm1=Arm1;
        Messager.Arm2=Arm2;
        Messager.Shoulder1=Shoulder1;
        Messager.Shoulder2=Shoulder2;
    }

    private void Pm01DataLoad()
    {
        Messager = GameObject.Find("DataMessager").GetComponent<DataMessager>();

        if (!Messager)
        {
            return;
        }

        Arm1 = Messager.Arm1;
        Arm2 = Messager.Arm2;
        Shoulder1 = Messager.Shoulder1;
        Shoulder2 = Messager.Shoulder2;
    }
}
