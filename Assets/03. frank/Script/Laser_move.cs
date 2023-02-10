using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_move : MonoBehaviour {
    private float speed = 0.5f;//弾速度
    private float moveX = 0f;
    private float moveY = 0f;
    private float moveZ = 0f;
    private Vector3 lastVelocity;//速度ベクトル
    private Rigidbody rb;//Rigidbody用
    private int time = 0;

    void Start () {
        rb = GetComponent<Rigidbody>();
        moveX = 10 * speed;
        
   //     rb.velocity = new Vector3(moveX, 0, 0);//初期ベクトル
    }
	
	void Update () {
        time++;
        if (time > 600)//600フレーム後に弾削除
        {
            transform.DetachChildren();//親オブジェクトから子オブジェクトを解除
            Destroy(gameObject);//弾削除
        }
    }

    void FixedUpdate()
    {
        this.lastVelocity = this.rb.velocity;//Rigidbodyを使用した移動用

    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Cube")//壁と当たった時
        {
            Vector3 refrectVec = Vector3.Reflect(this.lastVelocity, coll.contacts[0].normal);//反射ベクトル計算
            this.rb.velocity = refrectVec;
        }
        if (coll.gameObject.tag == "Cube_Destroy")//破壊出来る壁に当たった時
        {
            Destroy(coll.gameObject);//壁削除
            Vector3 refrectVec = Vector3.Reflect(this.lastVelocity, coll.contacts[0].normal);//反射ベクトル計算
            this.rb.velocity = refrectVec;
        }
        if (coll.gameObject.tag == "Player_Cube")//プレイヤーと当たった時
        {
            Vector3 refrectVec = Vector3.Reflect(this.lastVelocity, coll.contacts[0].normal);//反射ベクトル計算
            this.rb.velocity = refrectVec;
            Laser_Create.collision = 1;//赤く光らせる用
        }
    }



}
