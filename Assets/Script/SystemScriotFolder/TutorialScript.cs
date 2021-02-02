using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class TutorialScript : MonoBehaviour
{
    [SerializeField] Text defaultManualText, gameManualText,uiManualText,attackManualtext;
    [SerializeField] GameObject enemy;
    EnemyGenerate enemyGenerate;
    bool start = true;
    private void Start()
    {
        enemyGenerate = GameObject.Find("TutorialEnemy").GetComponent<EnemyGenerate>();
    }
    private void Update()
    {

        if (Input.GetButtonDown("Pause") && start)
        {
            defaultManualText.enabled = false;
            gameManualText.enabled = true;
            enemyGenerate.enemyGenerate = true;
        }
        if (Time.timeScale == 0)
        {
            uiManualText.enabled = true;
            defaultManualText.enabled = false;
            gameManualText.enabled = false;
            if (Input.GetButtonDown("Pause"))
            {
                Time.timeScale = 1;
                uiManualText.enabled = false;
                attackManualtext.enabled = true;
                start = false;
            }
        }
        if (!start)
        {
            if(Input.GetButtonDown("Fire2"))
            {
                // ガードのSpriteを表示
            }
        }
    }
    private void LoadScene()
    {

        SceneManager.LoadScene("GameScene");
    }
}
