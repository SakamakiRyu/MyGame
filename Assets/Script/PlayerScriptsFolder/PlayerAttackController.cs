using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerAttackController : MonoBehaviour
{
    /// <summary>武器の攻撃力</summary>
    [SerializeField] int attackPower = 5;

    private void OnTriggerEnter(Collider enemy)
    {
        GameObject enemyObject = enemy.gameObject;
        PlayerDate date = GameObject.Find("Player").GetComponent<PlayerDate>();

        if (enemyObject.tag == "Enemy")
        {
            EnemyDate enemyHp = enemy.gameObject.GetComponent<EnemyDate>();
            Animator enemyAnim = enemy.GetComponent<Animator>();

            enemyAnim.SetTrigger("EnemyGetHit");
            if ((date.baseAttackPower + attackPower) > enemyHp.enemyBlockPower)
            {
                enemyHp.enemyHitPoint -= (attackPower + date.baseAttackPower) - enemyHp.enemyBlockPower;
                Debug.Log(enemyObject.name + "に" + ((attackPower + date.baseAttackPower) - enemyHp.enemyBlockPower) + "のダメージ!");
                Debug.Log(enemyObject.name + "の残りHP : " + enemyHp.enemyHitPoint);
            }
            else if ((date.baseAttackPower + attackPower) <= enemyHp.enemyBlockPower)
            {
                enemyHp.enemyHitPoint -= 1;
                Debug.Log(enemyObject.name + "に 1 のダメージ!");
                Debug.Log(enemyObject.name + "の残りHP : " + enemyHp.enemyHitPoint);
            }
        }
    }
}
