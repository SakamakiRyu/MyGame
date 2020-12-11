using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerのデータ
/// </summary>
public class PlayerDate : MonoBehaviour
{
    /// <summary>名前</summary>
    [SerializeField] public string playerName = null;
    /// <summary>体力</summary>
    [SerializeField] public int hitPoint = 50;
    /// <summary>基礎攻撃力</summary>
    [SerializeField] public int baseAttackPower = 10;
    /// <summary>基礎防御力</summary>
    [SerializeField] public int baseBlockPower = 10;
    /// <summary>レベル</summary>
    [SerializeField] private int level = 1;
    /// <summary>経験値</summary>
    [SerializeField] public int exp = 0;
    /// <summary>レベルアップに必要な経験値</summary>
    [SerializeField] private int needExp = 100;
    public PlayerDate(string playerName)
    {
        this.playerName = playerName;
    }
    private void Update()
    {
        if (level <= 50 && exp >= needExp)
        {
            level++;
            Debug.Log("レベルが" + level + "に上がった");
            hitPoint += 1;
            baseAttackPower += 2;
            baseBlockPower += 2;
            if (level == 10 || level == 20 || level == 30 || level == 40)
            {
                baseAttackPower += 1;
                baseBlockPower += 1;
            }
            else if (level == 50)
            {
                baseAttackPower += 10;
                baseBlockPower += 10;
            }

            exp = exp - needExp;

            float fNeedExp;
            fNeedExp = needExp * 1.25f;
            needExp = (int)fNeedExp;
        }
    }
}