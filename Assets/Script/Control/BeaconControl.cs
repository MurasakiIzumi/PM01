using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconControl : MonoBehaviour
{
    public float speed;
    public float MaxY;
    public float GroundY;

    public GameObject KineticAttack;
    public GameObject Light;

    public Sprite Down;
    public Sprite Beacon;

    private SpriteRenderer spriterenderer;
    private Vector3 direction;                // 前進方向
    private bool isUp;
    private bool isDown;
    private bool isBeacon;
    private float timer;
    private float timeMax;

    void Start()
    {
        Light.SetActive(false);
        spriterenderer=this.GetComponent<SpriteRenderer>();
        direction = Vector3.up;
        isUp = true;
        isDown = false;
        isBeacon = false;
        timer = 0;
        timeMax = 5.0f;
    }

    void Update()
    {
        if (isUp)
        {
            // 座標移動計算
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            if (transform.position.y >= MaxY)
            {
                isUp = false;
                isDown = true;
                direction = Vector3.down;
                spriterenderer.sprite = Down;
            }
        }

        if (isDown)
        {
            // 座標移動計算
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            if (transform.position.y <= GroundY)
            {
                transform.position = new Vector3(transform.position.x, GroundY, transform.position.z);

                isDown = false;
                isBeacon = true;
                spriterenderer.sprite = Beacon;
            }
        }

        if (isBeacon)
        {
            Light.SetActive(true);

            timer += Time.deltaTime;

            if (timer >= timeMax)
            {
                Instantiate(KineticAttack, new Vector3(transform.position.x, GroundY + Light.transform.localScale.y, transform.position.z), Quaternion.identity);
                isBeacon = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroy(3rd)")
        {
            Destroy(gameObject);
        }
    }
}
