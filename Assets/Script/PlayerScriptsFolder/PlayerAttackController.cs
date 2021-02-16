using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerAttackController : MonoBehaviour
{
    /// <summary>武器の攻撃力</summary>
    [SerializeField] int attackPower = 5;
    PlayerDate playerDate;
    private void Start()
    {
        playerDate = GetComponentInParent<PlayerDate>();
    }
    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == "Enemy")
        {
            EnemyDate enemyHp = enemy.gameObject.GetComponent<EnemyDate>();
            Animator enemyAnim = enemy.GetComponent<Animator>();

            enemyAnim.SetTrigger("EnemyGetHit");
            if (playerDate.baseAttackPower + attackPower > enemyHp.enemyBlockPower)
            {
                enemyHp.nowEnemyHP -= (attackPower + playerDate.baseAttackPower) - enemyHp.enemyBlockPower;
            }
            else if (playerDate.baseAttackPower + attackPower <= enemyHp.enemyBlockPower)
            {
                enemyHp.nowEnemyHP -= 1;
            }
        }
    }
}
