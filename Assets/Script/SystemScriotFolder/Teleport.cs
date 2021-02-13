using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Teleport : MonoBehaviour
{
    /// <summary>移動先</summary>
    [SerializeField] Transform Destination;

    [SerializeField] OperationTheCamera camera;
    Text navText;
    GameObject player;
    /// <summary>テレポートのフラグ。trueの時に可能</summary>
    bool teleport = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        navText = GameObject.Find("Canvas/Text").GetComponent<Text>();
        camera = GameObject.Find("CameraSwitcher").GetComponent<OperationTheCamera>();
        navText.enabled = false;
    }
    private void Update()
    {
        if (teleport)
        {
            navText.enabled = true;

            if (camera.place == OperationTheCamera.PlayerNowPlace.NotHouse)
            {
                navText.text = "E : 家に入る";

                if (Input.GetButtonDown("Use"))
                {
                    Debug.Log("家に移動");
                    camera.place = OperationTheCamera.PlayerNowPlace.House;
                    player.transform.position = Destination.transform.position;
                }
            }
            else if (camera.place == OperationTheCamera.PlayerNowPlace.House)
            {
                navText.text = "E : 外に出る";

                if (Input.GetButtonDown("Use"))
                {
                    Debug.Log("外に移動");
                    camera.place = OperationTheCamera.PlayerNowPlace.NotHouse;
                    player.transform.position = Destination.transform.position;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            teleport = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            navText.enabled = false;
            teleport = false;
        }
    }
}
