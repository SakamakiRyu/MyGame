using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    AudioSource m_audio;
    [SerializeField] AudioClip m_bgm;
    [SerializeField] AudioClip m_combatBgm;
    bool m_isInCombat = false;
    List<int> m_combatTriggeredInstanceId = new List<int>();

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDefaultBGM(int instanceId)
    {
        Debug.Log("play defalut bgm");
        m_combatTriggeredInstanceId.Remove(instanceId);

        if (m_combatTriggeredInstanceId.Count < 1)
        {
            m_audio.Stop();
            m_audio.clip = m_bgm;
            m_audio.Play();
        }
    }

    public void PlayCombatBGM(int instanceId)
    {
        Debug.Log("play combat bgm");
        m_combatTriggeredInstanceId.Add(instanceId);

        if (m_combatTriggeredInstanceId.Count == 1)
        {
            m_audio.Stop();
            m_audio.clip = m_combatBgm;
            m_audio.Play();
        }
    }
}
