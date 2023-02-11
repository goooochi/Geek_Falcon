using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Tail_Enemy : MonoBehaviour
{
    private int time;//経過フレーム用

    // Start is called before the first frame update
    void Start()
    {
        time = 0;//初期化
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        if (time > 50)//60フレーム後に削除
        {
            Destroy(gameObject);
        }
    }
}
