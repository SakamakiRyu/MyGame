using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyAttackController : MonoBehaviour
{
    /// <summary>攻撃力</summary>
    [SerializeField] public int enemyAttackPower;
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
        if (other.tag == "Player")
        {
            playerAnim.SetTrigger("PlayerGetHit");
            if (enemyAttackPower > playerDate.baseBlockPower)
            {
                playerDate.nowHitPoint -= enemyAttackPower;
                Debug.Log(other.name + "に攻撃");
                Debug.Log(playerDate.name + "の残りHP : " + playerDate.nowHitPoint);
            }
            else if (enemyAttackPower <= playerDate.baseBlockPower)
            {
                playerDate.nowHitPoint -= 1;
                Debug.Log(other.name + "に攻撃");
                Debug.Log(playerDate.name + "の残りHP : " + playerDate.nowHitPoint);
            }
        }
    }
}