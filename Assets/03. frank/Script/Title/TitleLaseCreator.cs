using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // <-- これを追加してください

public class TitleLaseCreator : MonoBehaviour
{

    //private Vector3[] Laser_direction = { new Vector3(20f, 0f, 0f), new Vector3(5 * Mathf.Sqrt(3), 0f, 5f), new Vector3(5 * Mathf.Sqrt(2), 0f, 5 * Mathf.Sqrt(2)), new Vector3(5f, 0f, 5 * Mathf.Sqrt(3)), new Vector3(0f, 0f, 20f), new Vector3(-5f, 0f, 5 * Mathf.Sqrt(3)), new Vector3(-5 * Mathf.Sqrt(2), 0f, 5 * Mathf.Sqrt(2)), new Vector3(-5 * Mathf.Sqrt(3), 0f, 5f), new Vector3(-20f, 0f, 0), new Vector3(-5 * Mathf.Sqrt(3), 0f, -5f), new Vector3(-5 * Mathf.Sqrt(2), 0f, -5 * Mathf.Sqrt(2)), new Vector3(-5f, 0f, -5 * Mathf.Sqrt(3)), new Vector3(0f, 0f, -20f), new Vector3(5f, 0f, -5 * Mathf.Sqrt(3)), new Vector3(5 * Mathf.Sqrt(2), 0f, -5 * Mathf.Sqrt(2)), new Vector3(5 * Mathf.Sqrt(3), 0f, -5f) };
    private Vector3[] Laser_direction = { new Vector3(55f, 0f, 0f), new Vector3(30 * Mathf.Sqrt(3), 20f, 0), new Vector3(30 * Mathf.Sqrt(2), 30 * Mathf.Sqrt(2), 0), new Vector3(20f, 30 * Mathf.Sqrt(3), 0), new Vector3(0f, 55f, 0), new Vector3(-20f, 30 * Mathf.Sqrt(3), 0), new Vector3(-30 * Mathf.Sqrt(2), 30 * Mathf.Sqrt(2), 0), new Vector3(-30 * Mathf.Sqrt(3), 20f, 0), new Vector3(-55f, 0f, 0), new Vector3(-30 * Mathf.Sqrt(3), -20f, 0), new Vector3(-30 * Mathf.Sqrt(2), -30 * Mathf.Sqrt(2), 0), new Vector3(-20f, -30 * Mathf.Sqrt(3), 0), new Vector3(0f, -55f, 0), new Vector3(20f, -30 * Mathf.Sqrt(3), 0), new Vector3(30 * Mathf.Sqrt(2), -30 * Mathf.Sqrt(2), 0), new Vector3(30 * Mathf.Sqrt(3), -20f, 0) };
    public GameObject Laser_prefab_Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter(PointerEventData eventData)
    {
        Debug.Log("マウスが" + gameObject.name + "に触れた");
        // 何かしらの処理
        CreatePlayerLaser();
    }

    public void CreatePlayerLaser()
    {
        for (int i = 0; i < Laser_direction.Length; i++)
        {
            GameObject l = Instantiate(Laser_prefab_Player, this.transform.position, Quaternion.identity);
            l.GetComponent<Rigidbody>().velocity = Laser_direction[i];

        }
    }
}
