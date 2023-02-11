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
    void Start()
    {
        targetObject = GameObject.Find("unitychan(Clone)");
        target = targetObject.transform;
        agent = GetComponent<NavMeshAgent>();
        moveSpeed = agent.speed;
    }
    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position,target.position) < 30.0f)
        {
            agent.destination = target.position;
            agent.speed = moveSpeed;
        }
        else
        {
            agent.speed = 0;
        }
    }
}
