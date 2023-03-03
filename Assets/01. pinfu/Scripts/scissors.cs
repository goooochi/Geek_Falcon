using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scissors : MonoBehaviour
{
    public GameObject scissorsObject;
    private float timer;
    private float rondomTime;
    private int count;
    Vector3 player_position;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rondomTime = Random.Range(10, 20);
        player_position = GameObject.Find("unitychan(Clone)").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(count);
        timer += Time.deltaTime;
        if (timer >= rondomTime && count % 10 != 0)
        {
            count += 1;
            float x = Random.Range(-48, 48);
            float z = Random.Range(-48, 48);
            Instantiate(scissorsObject, new Vector3(x, 10, z), Quaternion.identity);
            timer = 0.0f;
            rondomTime = Random.Range(10, 20);
        }else if(timer >= rondomTime && count % 10 == 0)
        {
            float x = Random.Range(player_position.x - 10, player_position.x + 10);
            float z = Random.Range(player_position.z - 10, player_position.z + 10);
            Instantiate(scissorsObject, new Vector3(x, 10, z), Quaternion.identity);
            timer = 0.0f;
            rondomTime = Random.Range(10, 20);
        }
    }
}
