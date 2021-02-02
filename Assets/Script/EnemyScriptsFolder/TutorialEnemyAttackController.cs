using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TutorialEnemyAttackController : MonoBehaviour
{ 
    PlayerDate playerDate;
    Animator playerAnim;
    bool firstAttack = true;
    private void Start()
    {
        playerDate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDate>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerAnim.SetTrigger("PlayerGetHit");
            if (firstAttack)
            {
                playerDate.nowHitPoint -= 16;
                Time.timeScale = 0;
                firstAttack = false;
            }
        }
    }
}