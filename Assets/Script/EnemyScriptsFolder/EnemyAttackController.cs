using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyAttackController : MonoBehaviour
{
    /// <summary>攻撃力</summary>
    [SerializeField] public int enemyAttackPower;

    PlayerDate playerDate;
    PlayerController playerController;
    Animator playerAnim;

    private void Start()
    {
        enemyAttackPower = this.GetComponentInParent<EnemyDate>().enemyAttackPower;
        playerDate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDate>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (playerController.guard)
            {
                playerDate.nowHitPoint -= 1;
            }
            else
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
}