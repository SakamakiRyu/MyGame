using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator),typeof(EnemyDate))]
public class EnemyController : MonoBehaviour
{
    /// <summary>敵の移動速度</summary>
    [SerializeField] float moveSpeed = 2;
    /// <summary>敵の基本スピード</summary>
    [SerializeField] float enemySpeed = 2.5f;
    /// <summary>動き始める距離</summary>
    [SerializeField] float moveDistance = 10;
    /// <summary>キャラクターの死ぬモーションを入れる</summary>
    [SerializeField] GameObject deadObject = null;
    /// <summary>Playerとの距離</summary>
    float distance;

    [SerializeField] Collider m_attackTrigger = null;
    Transform target;
    Rigidbody e_rb;
    Animator e_anim;
    EnemyDate enemy;
    void Start()
    {
        e_anim = GetComponent<Animator>();
        e_rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = this.GetComponent<EnemyDate>();
    }
    void Update()
    {
        distance = (this.transform.position - target.position).magnitude;

        if (distance < moveDistance && distance >= 1.2f)
        {
            Vector3 playerPositon = target.transform.position;
            playerPositon.y = this.transform.position.y;
            this.transform.LookAt(playerPositon);
            e_rb.velocity = (transform.forward * moveSpeed);
        }
        else
        {
            e_rb.velocity = Vector3.zero;
        }
        if (enemy.enemyHitPoint >= 0)
        {
            PlayerDate player = GameObject.Find("Player").GetComponent<PlayerDate>();
            Debug.Log(this.gameObject.name + "を倒した");
            player.exp += enemy.enemyExp;
            Instantiate(deadObject, this.transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    private void LateUpdate()
    {
        Vector3 horizontalVelocity = e_rb.velocity;
        horizontalVelocity.y = 0;
        e_anim.SetFloat("Speed", horizontalVelocity.magnitude);
        e_anim.SetFloat("AttackDistance", distance);
    }
    void BeginAttackMotion()
    {
        moveSpeed = 0;
    }
    void EndAttackMotion()
    {
        moveSpeed = enemySpeed;
    }
    void BeginAttack()
    {
        if (m_attackTrigger)
        {
            m_attackTrigger.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 攻撃判定を無効にする
    /// </summary>
    void EndAttack()
    {
        if (m_attackTrigger)
        {
            m_attackTrigger.gameObject.SetActive(false);
        }
    }
}
