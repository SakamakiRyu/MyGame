using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
    /// <summary>PlayerのHPのスライダー</summary>
    [SerializeField] Slider hpSlider;
    /// <summary>PlayerのHP情報のテキスト</summary>
    [SerializeField] Text hpText;
    /// <summary>Playerの経験値のスライダー</summary>
    [SerializeField] Slider expSlider;
    /// <summary>Playerの経験値情報のテキストの</summary>
    [SerializeField] Text expText;
   
    PlayerDate playerDate;
    private void Start()
    {
        playerDate = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDate>();
        hpSlider.maxValue = playerDate.MaxHitPoint;
    }
    void Update()
    {
        expSlider.maxValue = playerDate.needExp;
        hpSlider.value = playerDate.nowHitPoint;
        hpText.text = "HP : " + playerDate.nowHitPoint + " / " + playerDate.MaxHitPoint;
        expSlider.value = playerDate.nowExp;
        expText.text = "EXP : " + playerDate.nowExp + " / " + playerDate.needExp;
    } 
}
