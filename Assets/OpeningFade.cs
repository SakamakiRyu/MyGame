using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningFade : MonoBehaviour
{
    [SerializeField] float time;
    private void Update()
    {
        time += Time.deltaTime * 1.0f;
        if (Input.anyKey)
        {
            time += 6;
        }
        if (time >= 6)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
