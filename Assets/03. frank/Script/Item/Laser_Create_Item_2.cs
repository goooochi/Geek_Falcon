using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Create_Item_2: MonoBehaviour
{
    private Vector3[] Laser_direction = { new Vector3(10f, 0f, 0f), new Vector3(5 * Mathf.Sqrt(3), 0f, 5f), new Vector3(5 * Mathf.Sqrt(2), 0f, 5 * Mathf.Sqrt(2)), new Vector3(5f, 0f, 5 * Mathf.Sqrt(3)), new Vector3(0f, 0f, 10f), new Vector3(-5f, 0f, 5 * Mathf.Sqrt(3)), new Vector3(-5 * Mathf.Sqrt(2), 0f, 5 * Mathf.Sqrt(2)), new Vector3(-5 * Mathf.Sqrt(3), 0f, 5f), new Vector3(-10f, 0f, 0), new Vector3(-5 * Mathf.Sqrt(3), 0f, -5f), new Vector3(-5 * Mathf.Sqrt(2), 0f, -5 * Mathf.Sqrt(2)), new Vector3(-5f, 0f, -5 * Mathf.Sqrt(3)), new Vector3(0f, 0f, -10f), new Vector3(5f, 0f, -5 * Mathf.Sqrt(3)), new Vector3(5 * Mathf.Sqrt(2), 0f, -5 * Mathf.Sqrt(2)), new Vector3(5 * Mathf.Sqrt(3), 0f, -5f) };
    public GameObject Laser_prefab_Item;
    public static Laser_Create_Item_2 instance;

    private int keyCounter = 0;
    private int maxLaserCount = 20;
    private bool isInstantiate = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateItemLaser()
    {
        if (keyCounter < maxLaserCount)
        {
            for (int i = 0; i < Laser_direction.Length; i++)
            {
                GameObject l = Instantiate(Laser_prefab_Item, this.transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
                l.GetComponent<Rigidbody>().velocity = Laser_direction[i];
            }
            keyCounter++;
        }
        else
        {
            CallWaitAndExecute();
        }
    }

    private IEnumerator WaitAndExecute()
    {
        isInstantiate = true;
        yield return new WaitForSeconds(4f);
        // 実行したい処理をここに書く
        keyCounter = 0;
        isInstantiate = false;
    }

    private void CallWaitAndExecute()
    {
        if (!isInstantiate)
        {
            StartCoroutine(WaitAndExecute());
        }
    }
}
