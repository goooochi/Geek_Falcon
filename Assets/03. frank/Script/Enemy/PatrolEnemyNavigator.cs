using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemyNavigator : MonoBehaviour
{

    public Transform[] points;
    [SerializeField] int destPoint = 0;
    private NavMeshAgent agent;

    Vector3 playerPos;
    public GameObject player;
    float distance;
    [SerializeField] float quitRange = 10f;
    [SerializeField] public bool tracking = false;


    public static PatrolEnemyNavigator instance;

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
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();

    }

    // Update is called once per frame
    void Update()
    {
        //Playerとこのオブジェクトの距離を測る
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);


        if (tracking)
        {
            Debug.Log("tracking");
            //追跡の時、quitRangeより距離が離れたら中止
            if (distance > quitRange)
            {
                Debug.Log("quitRange");
                tracking = false;
                Laser_Create_Enemy.instance.isChasing = false;
            }
                
            //Playerを目標とする
            agent.destination = playerPos;
        }
        else
        {
                
            // エージェントが現目標地点に近づいてきたら、次の目標地点を選択
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();
            }
        }
    }

    void GotoNextPoint()
    {
        // 地点がなにも設定されていないときにnullをかえす
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定し、必要ならば出発地点にもどる
        destPoint = (destPoint + 1) % points.Length;
    }

    void OnDrawGizmosSelected()
    {

        //quitRangeの範囲を青いワイヤーフレームで示す
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }

}
