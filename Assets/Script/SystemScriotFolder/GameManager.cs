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
    void Start()
    {
        Cursor.visible = false; // ゲームが始まったらマウスカーソルの表示を消す
        Cursor.lockState = CursorLockMode.Locked; // マウスカーソルを画面中央に固定する
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            restartButton.SetActive(true);
            itemPanel.SetActive(true);
        }
    }
    /// <summary>
    /// ゲームを再開する
    /// </summary>
    public void ReStartGame()
    {
        itemPanel.SetActive(false);
        restartButton.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}