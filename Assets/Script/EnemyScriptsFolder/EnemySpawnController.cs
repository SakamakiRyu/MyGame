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
    public List<bool> enemyAlive;
    /// <summary>敵を出現させる場所</summary>
    [SerializeField] Transform[] spawnPosition;
    void Start()
    {
        EnemyDate enemyDate = this.enemy.GetComponent<EnemyDate>();
        enemyDate.enemyLevel = Random.Range(enemyLevelMax, enemyLevelMin);
        enemyAlive = new List<bool>();
    }
    private void Update()
    {
        
    }
}
