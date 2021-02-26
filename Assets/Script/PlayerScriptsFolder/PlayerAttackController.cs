using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerAttackController : MonoBehaviour
{
    /// <summary>武器の攻撃力</summary>
    [SerializeField] int attackPower = 5;
    /// <summary>攻撃時に鳴らすサウンド</summary>
    [SerializeField] AudioClip swordAttackSE;
    /// <summary>攻撃を与えた際に発生させるプレハブ</summary>
    [SerializeField] GameObject hitEffect = null;

    AudioSource source;
    PlayerDate playerDate;
    private void Start()
    {
        playerDate = GetComponentInParent<PlayerDate>();
        source = this.GetComponentInParent<AudioSource>();
    }
    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.tag == "Enemy")
        {
            EnemyDate enemyDate = enemy.gameObject.GetComponent<EnemyDate>();
            Animator enemyAnim = enemy.GetComponent<Animator>();
            enemyDate.uiShow = true;
            if (hitEffect)
            {   
                Instantiate(hitEffect, enemy.transform.position, Quaternion.identity);
            }
            if (swordAttackSE)
            {
                source.PlayOneShot(swordAttackSE);
            }
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
