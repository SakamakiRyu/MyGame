using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Playerのデータ
/// </summary>
public class PlayerDate : MonoBehaviour
{
    /// <summary>Playerの名前</summary>
    [SerializeField] public string playerName = null;
    /// <summary>Playerの現在のHP</summary>
    [SerializeField] [Range(0, 100)] public int nowHitPoint = 100;
    /// <summary>Playerの最大HP</summary>
    [SerializeField] public int MaxHitPoint;
    /// <summary>Playerの基礎攻撃力</summary>
    [SerializeField] public int baseAttackPower = 10;
    /// <summary>Playerの基礎防御力</summary>
    [SerializeField] public int baseBlockPower = 10;
    /// <summary>レベル</summary>
    [SerializeField] [Range(1, 50)] private int level = 1;
    /// <summary>経験値</summary>
    [SerializeField] public int nowExp = 0;
    /// <summary>レベルアップに必要な経験値</summary>
    [SerializeField] public int needExp = 100;
    /// <summary>レベルが上がった際に再生するエフェクト</summary>
    [SerializeField] GameObject levelUpEffect;
   
    GameObject obj;
    GameObject player;
    Vector3 lvUpEffectPosition;
    
    public PlayerDate(string playerName)
    {
        this.playerName = playerName;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  
        MaxHitPoint = nowHitPoint;
    }
    private void Update()
    {
        if (level <= 50 && nowExp >= needExp)
        {
            lvUpEffectPosition = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f,player.transform.position.z);
            level++;
            Debug.Log("レベルが" + level + "に上がった");
            obj = (GameObject)Instantiate(levelUpEffect,lvUpEffectPosition, Quaternion.identity);
            obj.transform.parent = this.transform;
            baseAttackPower += 2;
            baseBlockPower += 2;
            nowHitPoint = 100; // レベルが上がったらHPを最大まで回復する
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

            nowExp = nowExp - needExp;

            float fNeedExp;
            fNeedExp = needExp * 1.25f;
            needExp = (int)fNeedExp;
        }
    }
}