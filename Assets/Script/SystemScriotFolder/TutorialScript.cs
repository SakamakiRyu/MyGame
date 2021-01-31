using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class TutorialScript : MonoBehaviour
{
    [SerializeField] Text defaultText , attackManualText;
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TextController(defaultText);
            TextController(attackManualText);
        }
    }
    private void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
    private void TextController(Text text)
    {
        if (text.enabled == true)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }
    }
}
