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
            EnemyDate enemyDate = enemy.gameObject.GetComponent<EnemyDate>();
            Animator enemyAnim = enemy.GetComponent<Animator>();
            enemyDate.uiShow = true;
            if (enemy.name == "Gobrin")
            {
                enemyAnim.SetTrigger("EnemyGetHit");
            }
            if (playerDate.baseAttackPower + attackPower > enemyDate.enemyBlockPower)
            {
                enemyDate.nowEnemyHP -= (attackPower + playerDate.baseAttackPower) - enemyDate.enemyBlockPower;
            }
            else if (playerDate.baseAttackPower + attackPower <= enemyDate.enemyBlockPower)
            {
                enemyDate.nowEnemyHP -= 1;
            }
        }
    }
}
