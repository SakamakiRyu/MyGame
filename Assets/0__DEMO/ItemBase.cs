using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アイテムクラス
/// </summary>
public class ItemBase : MonoBehaviour
{
    Vector3 itemStoragePosition = new Vector3(0, 5, 11);
    public virtual void Use()
    {
        Destroy(this.gameObject);
    }
}
