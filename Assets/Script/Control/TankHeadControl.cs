using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadControl : MonoBehaviour
{
    public GameObject player;
    public float rotationspeed;
    public float searchdis;

    [HideInInspector] private Vector3 ZreoY;
    [HideInInspector] private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        ZreoY = this.transform.position;
        target = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Player座標取得
        target = player.transform.position;
        target.y = ZreoY.y;

        //Playerがサーチ範囲内なら狙う
        if (Vector3.Distance(this.transform.position, player.transform.position) < searchdis)
        {
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(target - this.transform.position), rotationspeed * Time.deltaTime);
        }
    }
}
