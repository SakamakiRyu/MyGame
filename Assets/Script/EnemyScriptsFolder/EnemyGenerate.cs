using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    /// <summary>trueになった時に敵を生成</summary>
    public bool enemyGenerate = false;

    /// <summary>敵のPrefab</summary>
    [SerializeField] GameObject enemy;
    void Update()
    {
        if (enemyGenerate == true)
        {
            enemy.SetActive(true);
        }
    }
}
