using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDate : MonoBehaviour
{
    [SerializeField] public string enemyName = null;
    /// <summary>敵のHP</summary>
    [SerializeField] public int enemyHitPoint = 100;
    /// <summary>敵の攻撃力</summary>
    [SerializeField] public int enemyAttackPower = 10;
    /// <summary>敵の防御力</summary>
    [SerializeField] public int enemyBlockPower = 0;
    /// <summary>敵の保有経験値</summary>
    [SerializeField] public int enemyExp = 10;
    /// <summary>敵のレベル</summary>
    [SerializeField] public int enemyLevel;

    public EnemyDate(int enemyLevel)
    {
        this.enemyLevel = enemyLevel;
    }

    private void Start()
    {
       
        for (int i = 1; i < enemyLevel; i++)
        {
            enemyAttackPower += 2;
            enemyBlockPower += 2;
            enemyExp += 15;
        }
    }
}
