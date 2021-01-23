using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    EnemySpawnController enemySpawnController;
    void Start()
    {
        enemySpawnController = transform.root.GetComponent<EnemySpawnController>();
        enemySpawnController.enemyAlive[0] = false;
        Invoke("Dead", 3);
    }
    void Dead()
    {
        Destroy(this.gameObject);
    }
}
