using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Original
public class Laser_Create_Key : MonoBehaviour {


    private Vector3[] Laser_direction = {
        new Vector3(40f, 0f, 0f), new Vector3(20 * Mathf.Sqrt(3), 20f, 0f), new Vector3(20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2), 0f), new Vector3(20, 20 * Mathf.Sqrt(3), 0f),
        new Vector3(20 * Mathf.Sqrt(3), 0f, 20f),
        new Vector3(20 * Mathf.Sqrt(2), 0f, 20 * Mathf.Sqrt(2)), new Vector3(20 * Mathf.Sqrt(2), 20, 20 * Mathf.Sqrt(2)), new Vector3(20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2)),new Vector3(20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(3) , 20 * Mathf.Sqrt(2)),
        new Vector3(20f, 0f, 20 * Mathf.Sqrt(3)),
        new Vector3(0f, 0f, 40f), 
        new Vector3(-20f, 0f, 20 * Mathf.Sqrt(3)),
        new Vector3(-20 * Mathf.Sqrt(2), 0f, 20 * Mathf.Sqrt(2)),new Vector3(-20 * Mathf.Sqrt(2), 20, 20 * Mathf.Sqrt(2)),new Vector3(-20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2)), new Vector3(-20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(3), 20 * Mathf.Sqrt(2)),
        new Vector3(-20 * Mathf.Sqrt(3), 0f, 20f),
        new Vector3(-40f, 0f, 0), new Vector3(-20 * Mathf.Sqrt(3), 20f, 0f), new Vector3(-20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2), 0f), new Vector3(-20, 20 * Mathf.Sqrt(3), 0f),
        new Vector3(-20 * Mathf.Sqrt(3), 0f, -20f),
        new Vector3(-20 * Mathf.Sqrt(2), 0f, -20 * Mathf.Sqrt(2)), new Vector3(-20 * Mathf.Sqrt(2), 20, -20 * Mathf.Sqrt(2)), new Vector3(-20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2)),new Vector3(-20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(3) , 20 * Mathf.Sqrt(2)),
        new Vector3(-20f, 0f, -20 * Mathf.Sqrt(3)),
        new Vector3(0f, 0f, -40f), new Vector3(0, 20, -20 * Mathf.Sqrt(3)), new Vector3(0, 20 * Mathf.Sqrt(2), -20 * Mathf.Sqrt(2)),new Vector3(0, 20 * Mathf.Sqrt(3) , -20),
        new Vector3(20f, 0f, -20 * Mathf.Sqrt(3)),
        new Vector3(20 * Mathf.Sqrt(2), 0f, -20 * Mathf.Sqrt(2)), new Vector3(20 * Mathf.Sqrt(2), 20, -20 * Mathf.Sqrt(2)), new Vector3(20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(2), -20 * Mathf.Sqrt(2)),new Vector3(20 * Mathf.Sqrt(2), 20 * Mathf.Sqrt(3) , -20 * Mathf.Sqrt(2)),
        new Vector3(20 * Mathf.Sqrt(3), 0f, -20f)
    };

    public GameObject Laser_prefab;
    public static int collision = 0;
    public static Laser_Create_Key instance;
    public  bool canCreateLaser = true;
    float coolTime = 0.1f;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start () {
        
    }


	void Update () {

        if (coolTime > 0)
        {
            coolTime -= Time.deltaTime;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laser_prefab_Player(Clone)" && coolTime < 0)
        {
            for (int i = 0; i < Laser_direction.Length; i++)
            {
                GameObject l = Instantiate(Laser_prefab, this.transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
                l.GetComponent<Rigidbody>().velocity = Laser_direction[i];

            }
            coolTime = 0.1f;
        }
        
    }
    

}
