using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    /// <summary>出現させる敵のプレハブ</summary>
    [SerializeField] GameObject enemy;
    /// <summary>出現させる敵の最大レベル</summary>
    [SerializeField] int enemyLevelMax;
    /// <summary>出現させる敵の最小レベル</summary>
    [SerializeField] int enemyLevelMin;
    /// <summary>敵が存在するかのフラグ</summary>
    public bool[] enemyAlive;
    /// <summary>敵を出現させる場所</summary>
    [SerializeField] Transform[] spawnPosition;
    void Start()
    {
        EnemyDate enemyDate = this.enemy.GetComponent<EnemyDate>();
        enemyDate.enemyLevel = Random.Range(enemyLevelMax, enemyLevelMin);
        enemyAlive = new bool[spawnPosition.Length];
        for (int i = 0; i <= enemyAlive.Length - 1; i++)
        {
            enemyAlive[i] = false;
        }
    }
    private void Update()
    {
        Debug.Log(enemyAlive[0]);
        Debug.Log(enemyAlive[1]);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i <= enemyAlive.Length - 1; i++)
        {
            if (!enemyAlive[i])
            {
                enemyAlive[i] = true;
                Instantiate(enemy, spawnPosition[i]);
            }
        }
    }
}
