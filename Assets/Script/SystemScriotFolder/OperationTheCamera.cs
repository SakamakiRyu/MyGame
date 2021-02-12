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
        House,
        NotHouse
    }
    public PlayerNowPlace place = PlayerNowPlace.NotHouse;

    private void Update()
    {
        switch (place)
        {
            case PlayerNowPlace.House:
                playerCam.Priority = 0;
                houseCam.Priority = 1;
                break;
            case PlayerNowPlace.NotHouse:
                playerCam.Priority = 1;
                houseCam.Priority = 0;
                break;
            default:
                break;
        }
    }
}