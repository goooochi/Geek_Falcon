using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scissors : MonoBehaviour
{
    public GameObject scissorsObject;
    private float timer;
    private float rondomTime;
    // Start is called before the first frame update
    void Start()
    {
        rondomTime = Random.Range(10, 20);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= rondomTime)
        {
            float x = Random.Range(-48, 48);
            float z = Random.Range(-48, 48);
            Instantiate(scissorsObject, new Vector3(x, 10, z), Quaternion.identity);
            timer = 0.0f;
            rondomTime = Random.Range(10, 20);
        }
    }
}
