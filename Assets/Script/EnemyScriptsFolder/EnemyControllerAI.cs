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
    /// <summary>プレイヤーの追跡を始める距離</summary>
    [SerializeField] float beginMoveDistance;
    /// <summary>敵の移動スピード</summary>
    [SerializeField] float BaseSpeed = 3;
    /// <summary>ボスの強攻撃の際に発生させるエフェクト</summary>
    [SerializeField] GameObject attackEffect = null;

    Transform target;
    EnemyDate enemyDate;
    PlayerDate playerDate;
    NavMeshAgent navMesh;
    float distance = 100;

    void Start()
    {
        enemyDate = this.GetComponent<EnemyDate>();
        playerDate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDate>();
        navMesh = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (target)
        {
            distance = Vector3.Distance(this.gameObject.transform.position, target.position);

            if (distance <= beginMoveDistance)
            {
                navMesh.SetDestination(target.position);
            }
            else
            {
                navMesh.SetDestination(this.gameObject.transform.position);
            }

            if (enemyDate.nowEnemyHP <= 0)
            {
                Debug.Log(this.gameObject.name + "を倒した");
                playerDate.nowExp += enemyDate.enemyExp;
                GenerateDeadMotion();
                Destroy(this.gameObject);
            }
        }
        else
        {
            distance = 50;
        }
    }
    private void LateUpdate()
    {
        enemyAnim.SetFloat("Speed", navMesh.velocity.magnitude);
        enemyAnim.SetFloat("AttackDistance", distance);
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
    void PlayEffect()
    {
        Instantiate(attackEffect, this.attackTrigger.transform.position, Quaternion.identity);
    }
    void GenerateDeadMotion()
    {
        if (this.gameObject.name == "Gobrin")
        {
            Instantiate(deadPrefab, this.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(deadPrefab, this.transform.position, Quaternion.Euler(deadPrefab.transform.position));
        }
    }
}

