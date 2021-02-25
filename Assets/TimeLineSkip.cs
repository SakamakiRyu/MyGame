using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineSkip : MonoBehaviour
{
    [SerializeField] PlayableDirector director = null;

    private void Update()
    {
        if (Input.anyKey)
        {
            director.playableGraph.GetRootPlayable(0).SetSpeed(300.0f);
        }
    }
}
