using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject mouseCursor;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject itemPanel;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 0f;
            restartButton.SetActive(true);
            itemPanel.SetActive(true);
            // mouseCursor.SetActive(true);
        }
    }

    public void ReStartGame()
    {
        itemPanel.SetActive(false);
        restartButton.SetActive(false);
        // mouseCursor.SetActive(false);
        Time.timeScale = 1f;
    }
}
