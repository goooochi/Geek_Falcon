using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGeneScript : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    private Vector3[] Laser_direction = { new Vector3(10f, 0f, 0f), new Vector3(5 * Mathf.Sqrt(3), 0f, 5f), new Vector3(5 * Mathf.Sqrt(2), 0f, 5 * Mathf.Sqrt(2)), new Vector3(5f, 0f, 5 * Mathf.Sqrt(3)), new Vector3(0f, 0f, 10f), new Vector3(-5f, 0f, 5 * Mathf.Sqrt(3)), new Vector3(-5 * Mathf.Sqrt(2), 0f, 5 * Mathf.Sqrt(2)), new Vector3(-5 * Mathf.Sqrt(3), 0f, 5f), new Vector3(-10f, 0f, 0), new Vector3(-5 * Mathf.Sqrt(3), 0f, -5f), new Vector3(-5 * Mathf.Sqrt(2), 0f, -5 * Mathf.Sqrt(2)), new Vector3(-5f, 0f, -5 * Mathf.Sqrt(3)), new Vector3(0f, 0f, -10f), new Vector3(5f, 0f, -5 * Mathf.Sqrt(3)), new Vector3(5 * Mathf.Sqrt(2), 0f, -5 * Mathf.Sqrt(2)), new Vector3(5 * Mathf.Sqrt(3), 0f, -5f) };

    private void Start()
    {
        InvokeRepeating("Gene", 0, 1f);
    }
    void Gene()
    {
        for (int i = 0; i < Laser_direction.Length; i++)
        {
            GameObject l = Instantiate(laser, this.transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
            l.transform.parent = transform;
            l.GetComponent<Rigidbody>().velocity = Laser_direction[i];
        }
    }
}
