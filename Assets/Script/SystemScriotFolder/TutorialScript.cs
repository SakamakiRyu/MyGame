using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class TutorialScript : MonoBehaviour
{
    /// <summary>操作説明の各テキスト</summary>
    [SerializeField] Text start, w, a, s, d, sprint, jump, fire1, fire2, explanation1, explanation2, gamestart;
   // /// <summary>説明の音声</summary>
   // [SerializeField] AudioClip audio;

    private bool wkey = false, akey = false, skey = false, dkey = false, fire01 = false, fire02 = false, sprintkey = false, jumpkey = false, explnation01 = false, explnation02 = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (explnation01 == false && explnation02 == false)
            {
                Turorial0();
            }
        }
        if (explnation01 == true)
        {
            if (Input.GetButton("w"))
            {
                w.color = new Color(255, 0, 0);
                wkey = true;
                if (Input.GetButton("Sprint"))
                {
                    sprint.color = new Color(255, 0, 0);
                    sprintkey = true;
                }
            }
            if (Input.GetButtonDown("a"))
            {
                a.color = new Color(255, 0, 0);
                akey = true;
                if (Input.GetButtonDown("Sprint"))
                {
                    sprint.color = new Color(255, 0, 0);
                    sprintkey = true;
                }
            }
            if (Input.GetButtonDown("s"))
            {
                s.color = new Color(255, 0, 0);
                skey = true;
                if (Input.GetButtonDown("Sprint"))
                {
                    sprint.color = new Color(255, 0, 0);
                    sprintkey = true;
                }
            }
            if (Input.GetButtonDown("d"))
            {
                d.color = new Color(255, 0, 0);
                dkey = true;
                if (Input.GetButtonDown("Sprint"))
                {
                    sprint.color = new Color(255, 0, 0);
                    sprintkey = true;
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                jump.color = new Color(255, 0, 0);
                jumpkey = true;
            }
        }
        if (wkey == true && akey == true && skey == true && dkey == true && jumpkey == true && sprintkey == true)
        {
            Invoke("Tutorial1",1f);
        }
        if (explnation01 == false && explnation02 == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                fire1.color = new Color(255, 0, 0);
                fire01 = true;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                fire2.color = new Color(255, 0, 0);
                fire02 = true;
            }
            if (fire01 == true && fire02 == true)
            {
                explnation01 = true;
            }
        }
        if (explnation01 == true && explnation02 == true)
        {
            Invoke("Tutorial2", 1f);

            if (Input.GetButtonDown("Use"))
            {
                Invoke("LoadScene",1f);
            }
        }
    }
    private void Turorial0()
    {
        start.enabled = false;
        w.enabled = true;
        a.enabled = true;
        s.enabled = true;
        d.enabled = true;
        sprint.enabled = true;
        jump.enabled = true;
        explanation1.enabled = true;
        explnation01 = true;
    }
    private void Tutorial1()
    {
        explnation01 = false;
        explanation1.enabled = false;
        w.enabled = false;
        a.enabled = false;
        s.enabled = false;
        d.enabled = false;
        jump.enabled = false;
        sprint.enabled = false;

        fire1.enabled = true;
        fire2.enabled = true;
        explanation2.enabled = true;
        explnation02 = true;
    }
    private void Tutorial2()
    {
        gamestart.enabled = true;
        fire1.enabled = false;
        fire2.enabled = false;
        explanation1.enabled = false;
        explanation2.enabled = false;
    }
    private void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
