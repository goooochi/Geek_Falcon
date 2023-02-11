using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_position : MonoBehaviour
{
    public GameObject obj;
    public List<Transform> positions;
    void Awake()
    {
            Vector3 position = positions[Random.Range(0, positions.Count)].position;
            Instantiate(obj, position, Quaternion.identity);
    }
}
