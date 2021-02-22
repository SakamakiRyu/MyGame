using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerTest : MonoBehaviour
{
    [SerializeField] AudioClip battleBGM;
    [SerializeField] AudioClip notBattleBGM;
    [SerializeField] bool battleJudg = false;

    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }

    void Update()
    {
        if (battleJudg)
        {
            source.clip = battleBGM;
        }
        else
        {
            source.clip = notBattleBGM;
        }
    }
}
