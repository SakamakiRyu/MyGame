using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] float effectPlayTime;
    private void Start()
    {
        Destroy(this.gameObject, effectPlayTime);
    }
}
