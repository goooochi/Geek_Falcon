using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_ab_Script : MonoBehaviour
{
    GameObject targetObject;
    private Transform target;
    NavMeshAgent agent;
    float moveSpeed;
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
        if (Vector3.Distance(this.gameObject.transform.position,target.position) < 30.0f && PlayerController1.instance.crouch == false)
        {
            agent.destination = target.position;
            agent.speed = moveSpeed;
            enemyLaser.SetActive(true);
        }
        else if(PlayerController1.instance.crouch == true)
        {
            agent.speed = 0;
            enemyLaser.SetActive(false);
        }
        else
        {
            agent.speed = 0;
            enemyLaser.SetActive(false);
        }
    }
}
