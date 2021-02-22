using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyAttackController : MonoBehaviour
{
    /// <summary>攻撃力</summary>
    [SerializeField] public int enemyAttackPower;

    [SerializeField] GameObject attackEffect;
    PlayerDate playerDate;
    Animator playerAnim;

    private void Start()
    {
        enemyAttackPower = this.GetComponentInParent<EnemyDate>().enemyAttackPower;
        playerDate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDate>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" && attackEffect)
        {
            Instantiate(attackEffect, other.transform.position, Quaternion.identity);
        }

        if (other.tag == "Player")
        {
            playerAnim.SetTrigger("PlayerGetHit");

            if (enemyAttackPower > playerDate.baseBlockPower)
            {
                playerDate.nowHitPoint -= enemyAttackPower;
            }
            else if (enemyAttackPower <= playerDate.baseBlockPower)
            {
                playerDate.nowHitPoint -= 1;
            }
        }
    }
}