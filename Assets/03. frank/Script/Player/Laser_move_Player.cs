using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Original
public class Laser_move_Player : MonoBehaviour {

    
    private int time = 0;

    public GameObject originalLaser;
    //public GameObject greenLaser;

    //変更点
    private Vector3 lastVelocity;//速度ベクトル
    private Rigidbody rb;//Rigidbody用
    
    public static Laser_move_Player instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start () {
        rb = GetComponent<Rigidbody>();
        
    }
	
	void Update () {
        time++;
        if (time > 350)//60フレーム後に弾削除
        {
            transform.DetachChildren();//親オブジェクトから子オブジェクトを解除
            Destroy(gameObject);//弾削除
        }
    }

    void FixedUpdate()
    {
        this.lastVelocity = this.rb.velocity;//Rigidbodyを使用した移動用

    }


    private void OnCollisionEnter(Collision coll)
    {
        

        if (coll.gameObject.tag == "Cube")//壁と当たった時
        {
            Vector3 refrectVec = Vector3.Reflect(this.lastVelocity, coll.contacts[0].normal);//反射ベクトル計算
            this.rb.velocity = refrectVec;


        }

        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Nomal_Enemy")
        {
            enemyScript.isTrigger = true;
        }
        //colliderがついているのは、子オブジェクトであるため
        if (collider.transform.parent.name == "key_1_collider(Clone)")
        {
            Laser_Create_Item.instance.CreateItemLaser();
        }

        if (collider.transform.parent.name == "key_2_collider(Clone)")
        {
            Laser_Create_Item_2.instance.CreateItemLaser();
        }

        if (collider.transform.parent.name == "key_3_collider(Clone)")
        {
            Laser_Create_Item_3.instance.CreateItemLaser();
        }

    }
}
