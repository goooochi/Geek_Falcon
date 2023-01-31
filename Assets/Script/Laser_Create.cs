using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Create : MonoBehaviour {

    public GameObject Laser_prefab;//Laser_prefabをインスペクターに用意
    public GameObject Cube_prefab;
    public static int collision = 0;
    private int collision_time = 0;
    
    void Cube_Create()//壁生成   
    {      
        for (int i = 0; i < 5; i++)
        {          
            for (int j = 0; j < 5; j++)
            {               
                for (int k = 0; k < 7; k++)
                {
                    Cube_color.color = Random.Range(0, 6);//壁の色
                    Instantiate(Cube_prefab, new Vector3(j - 2, i - 2, k -3), Quaternion.identity);//壁生成                   
                }
            }
        }
    }
    void Start () {
          
    }
	
	void Update () {
        if(collision==1 && collision_time==0)
        {
            GetComponent<Renderer>().material.color = new Color32(255, 0, 0, 120);//弾に当たったら赤に変更する
        }
        
        if(collision==1)
        {
            collision_time++;
        }

        if(collision_time > 5)
        {
            collision = 0;
            collision_time = 0;
            GetComponent<Renderer>().material.color = new Color32(30, 255, 200, 120);//元の色に戻す
        }

       


        if (Input.GetMouseButton(0))//マウスを左クリックした時
        {
           
            Instantiate(Laser_prefab, Vector3.zero , Quaternion.identity);//左クリック位置にレーザー生成
        }
        if (Input.GetMouseButtonDown(1))
        {
            Cube_Create();//右クリック時、壁生成
        }

    }
}
