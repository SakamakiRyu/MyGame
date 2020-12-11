using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControllerAI : MonoBehaviour
{
    /// <summary>敵のアニメーション</summary>
    [SerializeField] Animator enemyAnim;
    /// <summary>敵のHPが0になった時に生成するオブジェクト</summary>
    [SerializeField] GameObject deadPrefab;
    /// <summary>攻撃判定</summary>
    [SerializeField] Collider attackTrigger = null;
    /// <summary>Playerの追跡を始める距離</summary>
    [SerializeField] float beginMoveDistance;
    /// <summary>敵の移動スピード</summary>
    [SerializeField] float BaseSpeed = 3;

    EnemyDate enemyDate;
    Vector3 targetPosition;
    Transform target;
    NavMeshAgent navMesh;
    float distance;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        enemyDate = this.GetComponent<EnemyDate>();
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        distance = Vector3.Distance(this.gameObject.transform.position, targetPosition);
        targetPosition = target.position;

        if (distance <= beginMoveDistance)
        {
            navMesh.SetDestination(targetPosition);
        }
        else if (distance >= beginMoveDistance)
        {
            navMesh.SetDestination(this.transform.position);
        }
        if (enemyDate.enemyHitPoint <= 0)
        {
            PlayerDate playerDate = GameObject.Find("Player").GetComponent<PlayerDate>();
            Debug.Log(this.gameObject.name + "を倒した");
            playerDate.exp += enemyDate.enemyExp;
            Instantiate(deadPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void LateUpdate()
    {
        enemyAnim.SetFloat("Speed",navMesh.velocity.magnitude);
        enemyAnim.SetFloat("AttackDistance",distance);
    }
    void BeginAttackMotion()
    {
        navMesh.speed = 0;
    }
    void EndAttackMotion()
    {
        navMesh.speed = BaseSpeed;
    }
    void BeginAttack()
    {
        if (attackTrigger)
        {
            attackTrigger.gameObject.SetActive(true);
        }
    }
    void EndAttack()
    {
        if (attackTrigger)
        {
            attackTrigger.gameObject.SetActive(false);
        }
    }
}

