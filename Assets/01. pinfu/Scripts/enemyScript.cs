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
    [SerializeField] private GameObject enemyLaser;
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
            agent.destination = target.position;
            agent.speed = moveSpeed;
            enemyLaser.SetActive(true);
        }
        else
        {
            agent.speed = 0;
            enemyLaser.SetActive(false);
        }

        if (Vector3.Distance(this.gameObject.transform.position, target.position) > 20.0f)
        {
            isTrigger = false;
        }
    }
    
}
