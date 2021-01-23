using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OperationTheCamera : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook playerCam;
    [SerializeField] CinemachineVirtualCamera houseCam;

    public enum PlayerNowPlace
    {
        p_house,
        p_notHouse
    }
    public PlayerNowPlace place = PlayerNowPlace.p_notHouse;

    private void Update()
    {
        switch (place)
        {
            case PlayerNowPlace.p_house:
                playerCam.Priority = 0;
                houseCam.Priority = 1;
                break;
            case PlayerNowPlace.p_notHouse:
                playerCam.Priority = 1;
                houseCam.Priority = 0;
                break;
            default:
                break;
        }
    }
}