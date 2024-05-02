using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lord : MonoBehaviour
{
    public GameObject Manager;

    public void LordScene()
    {
        int num = 0;

        if (Manager)
        {
            num = Manager.GetComponent<StageSelectManager>().Stage;
        }

        num++;
        SceneManager.LoadScene(num);
    }

    public void StageSelecetStep1(int num)
    {
        Manager.GetComponent<StageSelectManager>().StageSelecet(num);
    }

    public void ArmWeapon1(bool isR)
    {
        int Arm1 = Manager.GetComponent<StageSelectManager>().Arm1;

        if (isR)
        {
            Arm1++;
            if (Arm1 > 1)
            {
                Arm1 = 0;
            }
        }
        else
        {
            Arm1--;
            if (Arm1 < 0) 
            {
                Arm1 = 1;
            }
        }

        Manager.GetComponent<StageSelectManager>().Arm1 = Arm1;
    }

    public void ArmWeapon2(bool isR)
    {
        int Arm2 = Manager.GetComponent<StageSelectManager>().Arm2;

        if (isR)
        {
            Arm2++;
            if (Arm2 > 1)
            {
                Arm2 = 0;
            }
        }
        else
        {
            Arm2--;
            if (Arm2 < 0)
            {
                Arm2 = 1;
            }
        }

        Manager.GetComponent<StageSelectManager>().Arm2 = Arm2;
    }

    public void ShoulderWeapon1(bool isR)
    {
        int Shoulder1 = Manager.GetComponent<StageSelectManager>().Shoulder1;

        if (isR)
        {
            Shoulder1++;
            if (Shoulder1 > 2)
            {
                Shoulder1 = 0;
            }
        }
        else
        {
            Shoulder1--;
            if (Shoulder1 < 0)
            {
                Shoulder1 = 2;
            }
        }

        Manager.GetComponent<StageSelectManager>().Shoulder1 = Shoulder1;
    }

    public void ShoulderWeapon2(bool isR)
    {
        int Shoulder2 = Manager.GetComponent<StageSelectManager>().Shoulder2;

        if (isR)
        {
            Shoulder2++;
            if (Shoulder2 > 2)
            {
                Shoulder2 = 0;
            }
        }
        else
        {
            Shoulder2--;
            if (Shoulder2 < 0)
            {
                Shoulder2 = 2;
            }
        }

        Manager.GetComponent<StageSelectManager>().Shoulder2 = Shoulder2;
    }
}