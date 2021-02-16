using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : ItemBase
{
    [SerializeField] static string name;
    public override void Use()
    {
        Debug.Log(name + "を使った");
        base.Use();
    }
}
