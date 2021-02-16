using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOve : MonoBehaviour
{
    [SerializeField] Transform a;
    [SerializeField] Transform b;
    [SerializeField] bool move;
    [SerializeField] float speed;
    GameObject block;
    Rigidbody rb;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        speed = 5;
    }
    private void Update()
    {
        if (!move)
        {
           // this.transform.LookAt(a.position);
            Vector3 velo = a.position.normalized * speed;
            rb.velocity = velo;
        }
        else
        {
           // this.transform.LookAt(b.position);
            Vector3 velo = b.position.normalized * speed;
            rb.velocity = velo;
        }
    }
}
