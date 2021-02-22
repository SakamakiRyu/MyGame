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
    [SerializeField] Text assistText;
    /// <summary>ミニマップ</summary>
    [SerializeField] GameObject miniMap;
    void Start()
    {
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
            Time.timeScale = 0f;
            miniMap.SetActive(false);
            restartButton.SetActive(true);
            itemPanel.SetActive(true);
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
        Time.timeScale = 1f;
       
    }
}