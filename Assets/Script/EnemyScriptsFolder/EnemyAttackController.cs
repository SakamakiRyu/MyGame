using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyAttackController : MonoBehaviour
{
    /// <summary>攻撃力</summary>
    [SerializeField] public int enemyAttackPower = 5;
    
    private void OnTriggerEnter(Collider other)
    {
        GameObject gameObject = other.gameObject;
        if (gameObject.tag == "Player")
        {
            PlayerDate player = other.gameObject.GetComponent<PlayerDate>();
            Animator animator = other.gameObject.GetComponent<Animator>();
            animator.SetTrigger("PlayerGetHit");

            if (enemyAttackPower > player.baseBlockPower)
            {
                player.hitPoint -= enemyAttackPower;
                Debug.Log(other.name + "に攻撃");
                Debug.Log(player.name + "の残りHP : " + player.hitPoint);
            }
            else if (enemyAttackPower <= player.baseBlockPower)
            {
                player.hitPoint -= 1;
                Debug.Log(other.name + "に攻撃");
                Debug.Log(player.name + "の残りHP : " + player.hitPoint);
            }
        }
    }
}