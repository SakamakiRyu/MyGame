using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }
}
