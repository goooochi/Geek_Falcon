using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_move_title: MonoBehaviour
{

    private int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time > 200)//5フレーム後に弾削除
        {
            transform.DetachChildren();//親オブジェクトから子オブジェクトを解除
            Destroy(gameObject);//弾削除
        }
    }
}
