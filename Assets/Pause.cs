using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseUIPrefab;

    private GameObject pauseUIINstance;
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (pauseUIINstance == null)
            {
                pauseUIINstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(pauseUIINstance);
                Time.timeScale = 1f;
            }
        }
    }
}
