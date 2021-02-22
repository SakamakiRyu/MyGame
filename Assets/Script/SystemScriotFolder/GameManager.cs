using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class GameManager : MonoBehaviour
{
    /// <summary>ゲームを再開するボタン</summary>
    [SerializeField] GameObject restartButton;
    /// <summary>アイテムパネル</summary>
    [SerializeField] GameObject itemPanel;
    /// <summary>マウスカーソルの表示を操作するフラグ</summary>
    [SerializeField] bool mouseCursorControlle;
    /// <summary>ゲーム進行のアシストをするテキスト</summary>
    [SerializeField] Text naviText;
    /// <summary>ミニマップ</summary>
    [SerializeField] GameObject miniMap;
    /// <summary>モブ戦闘中に流れるBGM</summary>
    [SerializeField] AudioClip battleBGM;
    /// <summary>ボス戦闘中に流れるBGM</summary>
    [SerializeField] AudioClip bossBattleBGM;
    /// <summary>普段流れるBGM </summary>
    [SerializeField] AudioClip usuallyBGM;
    /// <summary>設定画面に移行する時の鳴らすSE</summary>
    [SerializeField] AudioClip editSE;
  
    /// <summary>再生時間を保存しておく変数</summary>
    float bgmTime;
    AudioSource source;
   
    void Start()
    {
        source = GetComponent<AudioSource>();

        if (mouseCursorControlle)
        {
            Cursor.visible = false; // ゲームが始まったらマウスカーソルの表示を消す
            Cursor.lockState = CursorLockMode.Locked; // マウスカーソルを画面中央に固定する
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (mouseCursorControlle)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            Time.timeScale = 0f; //ゲームの進行スピードを止める
            miniMap.SetActive(false); 
            restartButton.SetActive(true);
            itemPanel.SetActive(true);
            source.PlayOneShot(editSE); // 設定画面移行のSEを鳴らす
            bgmTime = source.time; // BGMの再生時間を保存する
            source.Stop(); // BGMを止める
        }
    }
    /// <summary>
    /// ゲームを再開する
    /// </summary>
    public void ReStartGame()
    {
        if (mouseCursorControlle)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        miniMap.SetActive(true);
        itemPanel.SetActive(false);
        restartButton.SetActive(false);
        Time.timeScale = 1f; // ゲームの進行スピードを通常に戻す
        source.time = bgmTime; // 保存した再生時間を設定する
        source.Play(); // BGMを再生する
    }
}