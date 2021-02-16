using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///キャラクター操作のクラス
/// </summary>
public class CharactorController : MonoBehaviour
{
    [SerializeField] int speed = 5;
    [SerializeField] GameObject levelUpEffect;
    GameObject player;
    Vector3 effPosotion;
    Rigidbody rb;
    GameObject obj;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        
    }
    void Update()
    {
        effPosotion = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 v3 = Vector3.forward * v + Vector3.right * h;

        if (v3 == Vector3.zero)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        else
        {
            Vector3 velo = v3.normalized * speed;
            rb.velocity = velo;
        }

        if (Input.GetButtonDown("Jump"))
        {
            obj = (GameObject)Instantiate(levelUpEffect, effPosotion, Quaternion.identity);
            obj.transform.parent = this.transform;
        }
    }
}
