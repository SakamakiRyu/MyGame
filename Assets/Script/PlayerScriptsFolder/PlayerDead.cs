using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDead : MonoBehaviour
{
    void Start()
    {
       // Invoke("PlayerDeadMethod", 6f);
    }
    void PlayerDeadMethod()
    {
        SceneManager.LoadScene("");
    }
}
