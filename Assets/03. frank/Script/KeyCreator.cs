using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCreator : MonoBehaviour
{

    public Transform[] keyPoints;
    public GameObject key;

    private void Awake()
    {
        Instantiate(key, keyPoints[Random.Range(0, keyPoints.Length)].position + new Vector3(0, -0.25f, 0), Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyCreate()
    {
        
    }
}
