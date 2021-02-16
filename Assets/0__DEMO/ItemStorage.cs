using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// アイテム管理クラス
/// </summary>
public class ItemStorage : MonoBehaviour
{
    /// <summary>アイテムの収容量</summary>
    [SerializeField] static int capacity;
    /// <summary>アイテムメニュー</summary>
    [SerializeField] GameObject itemStorage;
    /// <summary>アイテムを保管しておく配列</summary>
    GameObject[] items = new GameObject[capacity];
      
    void GetImage(Image image)
    {
        
    }

    void Reflect(int storageNum)
    {
        
    }

    public void ShowItem()
    {
        itemStorage.SetActive(true);
    }
}
