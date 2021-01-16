using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamaraSwitch : MonoBehaviour
{
    [SerializeField] Transform[] transform;
    [SerializeField] Transform entrance;
    [SerializeField] Transform exit;
    [SerializeField] GameObject player;
    CinemachineFreeLook playerCam;
    CinemachineVirtualCamera houseCam;
    public string place = "outside";
    private void Start()
    {
        playerCam = GameObject.Find("PlayerFollowCam").GetComponent<CinemachineFreeLook>();
        houseCam = GameObject.Find("HouseCam").GetComponent<CinemachineVirtualCamera>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Use"))
            {
                if (place == "outside")
                {
                    Debug.Log("家に入った");
                    player.transform.position = entrance.position;
                    player.transform.rotation = other.transform.rotation;
                    place = "house";
                    playerCam.Priority = houseCam.Priority - 1;
                }
                else if (place == "house")
                {
                    Debug.Log("外に出た");
                    player.transform.position = exit.position;
                    player.transform.rotation = other.transform.rotation;
                    place = "outside";
                    houseCam.Priority = playerCam.Priority - 1;
                }
            }
        }
    }
}
