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
    /// <summary>攻撃時に再生するSE</summary>
    [SerializeField] AudioClip attackSE;
    /// <summary>Playerのトランスフォームを保存しておく変数</summary>
    Transform target;
    /// <summary>自身の音をならすSource</summary>
    AudioSource source;
    /// <summary>ゲームのBGMを管理するSource</summary>
    GameManager gameManager;

    EnemyDate enemyDate;
    PlayerDate playerDate;
    NavMeshAgent navMesh;
    float distance = 100;
    bool nowBattle = false;
    
    void Start()
    {
        enemyDate = this.GetComponent<EnemyDate>();
        playerDate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDate>();
        navMesh = this.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        source = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (target)
        {
            distance = Vector3.Distance(this.gameObject.transform.position, target.position);
            if (distance <= beginMoveDistance && !nowBattle)
            {
                navMesh.SetDestination(target.position);
                nowBattle = true;
                GameObject.Find("BgmManager").GetComponent<BGMController>()?.PlayCombatBGM(this.gameObject.GetInstanceID());
            }
            else if (distance > beginMoveDistance && nowBattle)
            {
                navMesh.SetDestination(this.gameObject.transform.position);
                nowBattle = false;
                GameObject.Find("BgmManager").GetComponent<BGMController>()?.PlayDefaultBGM(this.gameObject.GetInstanceID());
            }

            if (enemyDate.nowEnemyHP <= 0)
            {
                Debug.Log(this.gameObject.name + "を倒した");
                playerDate.nowExp += enemyDate.enemyExp;
                nowBattle = false;
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
    void PlaySE(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    /// <summary>
    /// 死にモーションを生成するメソッド
    /// </summary>
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

