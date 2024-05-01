using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;
using Image = UnityEngine.UI.Image;

public class ControlPlayer : MonoBehaviour
{
    //各部位
    [Header("[プレイヤーの各部位]")]
    public ControlBackArm part_backarm;
    public ControlBody part_body;
    public ControlFrontArm part_frontarm;
    public ControlLaserGun part_lasergun;
    public ControlBeaconLancher part_beaconlancher;
    public ControlLeg part_leg;
    public ControlRocketLancher part_rocketlancher;
    public ControlMortarGun part_mortargun;

    public int ArmR = 1;
    public int ArmL = 1;
    public int shoulderR = 1;
    public int shoulderL = 1;

    [Header("UI関連")]
    public Image hpbar;
    public Image powerbar;
    public Text AmmoRight;
    public Text AmmoLeft;
    public Text AmmoRocket;

    [Header("跳躍高さ")] public float jumphigh;
    [Header("移動スピード")] public float move_speed;                                    // 移動速度

    [Header("HP&Power")]
    public float HpMax;
    [HideInInspector] public float Hp;
    public float HpreplySpeed;
    public float PowerMax;
    [HideInInspector] public float Power;
    public float PowerreplySpeed;
    [HideInInspector] public bool isstart;

    [Header("Ammo")]
    public int ammobulletMax;
    public int ammorocketMax;

    [HideInInspector] public int ammoright;
    [HideInInspector] public int ammoleft;
    [HideInInspector] public int ammorocket;

    [HideInInspector] public int dir;                           // 向き（2上 4左 8下 6右）
    [HideInInspector] public bool canRun;
    [HideInInspector] public bool flipx;
    [HideInInspector] public bool isJump;
    [HideInInspector] public bool HpRun;

    private IState currentState;

    private void Awake()
    {

    }

    void Start()
    {
        dir = 6;                    // 登場時の向き（右）
        canRun=false;
        flipx =false;
        isJump=false;
        isstart = true;
        HpRun = false;
        Hp = 0;
        Power = 0;
        ammoright = ammobulletMax;
        ammoleft = ammobulletMax;
        ammorocket = ammorocketMax;

        ArmWeaponCheck();
        ShoulderWeaponCheck();
    }

    void Update()
    {
        //HP&Power関連
        if (HpRun)
        {
            if (isstart)
            {
                Hp += PowerreplySpeed * Time.deltaTime * 3.0f;
                Power += PowerreplySpeed * Time.deltaTime * 2.0f;
                if (Hp >= HpMax)
                {
                    isstart = false;
                }
            }

            Hp += HpreplySpeed * Time.deltaTime;
            Hp = Math.Min(Hp, HpMax);
            hpbar.fillAmount = Hp / 100.0f;

            Power += PowerreplySpeed * Time.deltaTime;
            Power = Math.Max(0.0f, Math.Min(Power, PowerMax));
            powerbar.fillAmount = Power / 100.0f;
        }

        //Ammo関連
        if (ammoright > 0)
        {
            if (ammoright <= ammobulletMax/4)
            {
                AmmoRight.color = Color.red;
            }
            else if (ammoright <= ammobulletMax/3)
            {
                AmmoRight.color = Color.yellow;
            }

            AmmoRight.text = "" + ammoright;
        }
        else
        {
            AmmoRight.text = "Out";
        }

        if (ammoleft > 0)
        {
            if (ammoleft <= ammobulletMax / 4)
            {
                AmmoLeft.color = Color.red;
            }
            else if (ammoleft <= ammobulletMax / 3)
            {
                AmmoLeft.color = Color.yellow;
            }

            AmmoLeft.text = "" + ammoleft;
        }
        else
        {
            AmmoLeft.text = "Out";
        }

        if (ammorocket > 0)
        {
            if (ammorocket <= ammorocketMax / 4)
            {
                AmmoRocket.color = Color.red;
            }
            else if (ammorocket <= ammorocketMax / 3)
            {
                AmmoRocket.color = Color.yellow;
            }

            AmmoRocket.text = "" + ammorocket;
        }
        else 
        {
            AmmoRocket.text = "Out";
        }
    }

    public void SetSpriteFlip(bool flip)
    {
        if (flip == true)
        {
            if (part_backarm && part_body && part_frontarm && part_lasergun && part_leg && part_rocketlancher)
            {
                part_backarm.spriteRenderer.flipX = true;
                part_body.spriteRenderer.flipX = true;
                part_frontarm.spriteRenderer.flipX = true;
                part_lasergun.spriteRenderer.flipX = true;
                part_beaconlancher.spriteRenderer.flipX = true;
                part_leg.spriteRenderer.flipX = true;
                part_rocketlancher.spriteRenderer.flipX = true;
                part_mortargun.spriteRenderer.flipX = true;
                flipx = true;

                this.GetComponent<BoxCollider>().center = ColliderFlip(this.GetComponent<BoxCollider>().center);
            }
        }
        else if (flip == false)
        {
            if (part_backarm && part_body && part_frontarm && part_lasergun && part_leg && part_rocketlancher)
            {
                part_backarm.spriteRenderer.flipX = false;
                part_body.spriteRenderer.flipX = false;
                part_frontarm.spriteRenderer.flipX = false;
                part_lasergun.spriteRenderer.flipX = false;
                part_beaconlancher.spriteRenderer.flipX = false;
                part_leg.spriteRenderer.flipX = false;
                part_rocketlancher.spriteRenderer.flipX = false;
                part_mortargun.spriteRenderer.flipX = false;
                flipx = false;

                this.GetComponent<BoxCollider>().center = ColliderFlip(this.GetComponent<BoxCollider>().center);
            }
        }
    }

    private Vector3 ColliderFlip(Vector3 vec)
    {
        Vector3 newvec = vec;
        newvec.x *= -1.0f;

        return newvec;
    }

    private void ArmWeaponCheck()
    {
        switch (ArmR)
        {
            case 0:
                part_frontarm.gameObject.SetActive(false);
                break;
            case 1:
                break;
        }

        switch (ArmL)
        {
            case 0:
                part_backarm.gameObject.SetActive(false);
                break;
            case 1:
                break;
        }
    }

    private void ShoulderWeaponCheck()
    {
        switch (shoulderR)
        {
            case 0:
                part_rocketlancher.gameObject.SetActive(false);
                part_mortargun.gameObject.SetActive(false);
                break;
            case 1:
                part_mortargun.gameObject.SetActive(false);
                break;
            case 2:
                part_rocketlancher.gameObject.SetActive(false);
                break;
        }

        switch (shoulderL)
        {
            case 0:
                part_lasergun.gameObject.SetActive(false);
                part_beaconlancher.gameObject.SetActive(false);
                break;
            case 1:
                part_beaconlancher.gameObject.SetActive(false);
                break;
            case 2:
                part_lasergun.gameObject.SetActive(false);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet(Enemy)")
        {
            Hp -= other.GetComponent<EnemyBulletControl>().damage;
            other.GetComponent<EnemyBulletControl>().Hit();
        }

        if (other.gameObject.tag == "Cannon(Enemy)")
        {
            Hp -= other.GetComponent<EnemyCannonControl>().damage;
            other.GetComponent<EnemyCannonControl>().Hit();
        }

        if (other.gameObject.tag == "Destroy(3rd)")
        {
            Hp = -1;
        }
    }
}
