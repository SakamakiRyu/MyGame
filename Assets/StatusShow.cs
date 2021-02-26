using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusShow : MonoBehaviour
{
    /// <summary>ステータスを表示するテキスト</summary>
    [SerializeField] Text level,hitPoint, exp, attackPower, blockPower;
    PlayerDate date;

    private void Start()
    {
        date = GameObject.Find("Player").GetComponent<PlayerDate>();
    }
   
    public void Update()
    {
        level.text ="レベル : " + date.level.ToString();
        hitPoint.text = "体力   : " + date.nowHitPoint + " / " + date.MaxHitPoint;
        exp.text = "経験値  : " + date.nowExp + " / " + date.needExp;
        attackPower.text = "攻撃力 : " + date.baseAttackPower.ToString();
        blockPower.text = "防御力 : " + date.baseBlockPower.ToString();
    }
}
