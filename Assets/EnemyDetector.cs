using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] GameObject enemy = null;
    [SerializeField] bool enemyDetector = false;
    
    void Update()
    {
        if (!enemyDetector)
        {
            Generate(enemy);
        }
    }

    void Generate(GameObject enemy)
    {
        Instantiate(enemy, this.transform.position, Quaternion.identity);
        enemyDetector = true;
    }
}
