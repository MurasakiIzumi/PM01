using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MortarControl : MonoBehaviour
{
    public float speed;
    [Header("����")] public GameObject explosion;
    [Header("����")] public GameObject smoke;
    [Header("�摜2")] public Sprite ModeUp;


    [HideInInspector] public int dir;
    [HideInInspector] public bool Mode;
    private Vector3 direction;                // �O�i����
    private Vector3 Angle;                    // ����
    private bool isUp;
    private float timer;
    private float timeMax;
    private float timer_smoke;
    private float timeMax_smoke;


    void Start()
    {
        Angle = transform.eulerAngles;

        if (Mode)
        {
            direction = new Vector3(0.8f, 0.8f, 0);
            gameObject.GetComponent<SpriteRenderer>().sprite = ModeUp;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
            Angle.z = 45.0f;
            transform.eulerAngles = Angle;
        }
        else 
        {
            direction = new Vector3(1.0f, 0.0f, 0);
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }

        isUp = true;
        timer = 0;
        timeMax = 1.5f;
        timer_smoke = 0;
        timeMax_smoke = 0.1f;

        if (dir == 4)
        {
            direction.x *= -1.0f;
        }
    }

    void Update()
    {
        if (isUp)
        {
            // ���W�ړ��v�Z
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // �^�C�}�[�X�V
            timer += Time.deltaTime;

            if (timer >= timeMax)
            {
                isUp = false;
                direction.y = 0;
                GetComponent<Rigidbody>().useGravity = true;
                timer = 0;
                speed *= 0.5f;
                Angle.z = -45.0f;
                transform.eulerAngles = Angle;
            }
        }
        else
        {
            // ���W�ړ��v�Z
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // �^�C�}�[�X�V
            timer += Time.deltaTime;

            if (timer >= timeMax)
            {
                Destroy(gameObject);
            }
        }

        if (timer_smoke >= timeMax_smoke)
        {
            SetSmoke();
            timer_smoke = 0;
        }
        else
        {
            timer_smoke += Time.deltaTime;
        }
    }
    private void SetSmoke()
    {
        Instantiate(smoke, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Mode)
        {
            if (other.tag == "Ground")
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        else
        {
            if (other.tag == "Enemy")
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
