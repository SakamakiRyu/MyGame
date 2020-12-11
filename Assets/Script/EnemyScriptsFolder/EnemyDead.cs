using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    void Start()
    {
        Invoke("Dead", 3);
    }
    void Dead()
    {
        Destroy(this.gameObject);
    }
}
