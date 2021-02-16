using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDate : MonoBehaviour
{
    [SerializeField] public string enemyName = null;
    /// <summary>敵のHP</summary>
    [SerializeField] public int nowEnemyHP;
    /// <summary>敵の最大HP</summary>
    [SerializeField] private int MaxHP;
    /// <summary>敵の攻撃力</summary>
    [SerializeField] public int enemyAttackPower = 10;
    /// <summary>敵の防御力</summary>
    [SerializeField] public int enemyBlockPower = 0;
    /// <summary>敵の保有経験値</summary>
    [SerializeField] public int enemyExp = 10;
    /// <summary>敵のレベル</summary>
    [SerializeField] public int enemyLevel;
    /// <summary>HPのスライダー</summary>
    [SerializeField] Slider hpSlider;
    /// <summary>レベルのテキスト表示</summary>
    [SerializeField] Text lvText;
    /// <summary>UIのキャンバス</summary>
    [SerializeField] Canvas uiCanvas;
    /// <summary>HPのUI表示のフラグ</summary>
    [SerializeField] public bool uiShow = false;

    private void Start()
    {
        MaxHP = nowEnemyHP;
        hpSlider.maxValue = MaxHP;
        lvText.text = "Lv : " + enemyLevel;
        EnemyStatusDetector(this.enemyName);
        uiCanvas.enabled = false;
    }
    private void Update()
    {
        hpSlider.value = nowEnemyHP;
        uiCanvas.transform.rotation = Camera.main.transform.rotation;
        if (uiShow)
        {
            uiCanvas.enabled = true;
        }
    }
    void EnemyStatusDetector(string name)
    {
        if (name == "Gobrin")
        {
            for (int i = 1; i < enemyLevel; i++)
            {
                enemyAttackPower += 2;
                enemyExp += 15;
            }
        }
        else if (name == "Skeleton")
        {
            for (int i = 1; i < enemyLevel; i++)
            {
                enemyAttackPower += 2;
                enemyBlockPower += 1;
                nowEnemyHP += 15;
                enemyExp += 30;
            }
        }
        else 
        {
            for (int i = 1; i < enemyLevel; i++)
            {
                enemyAttackPower += 3;
                enemyBlockPower += 2;
                nowEnemyHP += 50;
                enemyExp += 100;
            }
        }
    }
}
