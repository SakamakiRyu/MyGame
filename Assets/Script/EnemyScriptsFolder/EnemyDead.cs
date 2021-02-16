using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField] float dethTime;
    [SerializeField] GameObject DethEffect;
    void Start()
    {
        Instantiate(DethEffect, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject, dethTime);
    }
}
