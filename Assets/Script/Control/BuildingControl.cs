using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingControl : MonoBehaviour
{
    [HideInInspector] private int hp;
    [HideInInspector] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            transform.position -= new Vector3(0, 1.0f, 0) * speed * Time.deltaTime;
        }

        if(transform.position.y<-5.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= other.GetComponent<BulletControl>().damage;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Rocket")
        {
            hp -= other.GetComponent<RocketContrl>().damage;
            other.GetComponent<RocketContrl>().DestroySelf();
        }

        if (other.gameObject.tag == "Laser")
        {
            hp -= other.GetComponent<LaserControl>().damage;
        }

        if (other.gameObject.tag == "Destroy")
        {
            hp = -1;
        }

        if (other.gameObject.tag == "Destroy(3rd)")
        {
            hp = -1;
        }
    }
}
