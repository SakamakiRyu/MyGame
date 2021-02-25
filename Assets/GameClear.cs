using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameClear : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneManager.LoadScene("GameClear");
    }
}
