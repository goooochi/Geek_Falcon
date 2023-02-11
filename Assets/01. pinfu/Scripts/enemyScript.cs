using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    GameObject targetObject;
    private Transform target;
    NavMeshAgent agent;
    float moveSpeed;
    public static bool isTrigger;
    
    void Start()
    {
        targetObject = GameObject.Find("unitychan(Clone)");
        target = targetObject.transform;
        agent = GetComponent<NavMeshAgent>();
        moveSpeed = agent.speed;
    }
    void Update()
    {
        if (isTrigger)
        {
            Debug.Log("正常");
            agent.destination = target.position;
            agent.speed = moveSpeed;
        }
        else
        {
            agent.speed = 0;
        }

        if (Vector3.Distance(this.gameObject.transform.position, target.position) > 20.0f)
        {
            isTrigger = false;
        }
    }
}
