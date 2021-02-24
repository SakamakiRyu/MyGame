using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningFade : MonoBehaviour
{
    float time;
    private void Update()
    {
        time += Time.deltaTime * 1.0f;
        if (Input.GetButtonDown("Jump"))
        {
            time = 4;
        }
        if (time >= 4)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
