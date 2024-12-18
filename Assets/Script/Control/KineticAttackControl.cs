using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticAttackControl : MonoBehaviour
{
    public float speed;

    [Header("爆発")] public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 座標移動計算
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
