using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Teleport : MonoBehaviour
{
    /// <summary>移動先</summary>
    [SerializeField] Transform Destination;

    OperationTheCamera camera;
    Text text;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        camera = GameObject.Find("CameraSwitcher").GetComponent<OperationTheCamera>();
        text.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            text.enabled = true;

            if (camera.place == OperationTheCamera.PlayerNowPlace.p_notHouse)
            {
                text.text = "E : 家に入る";

                if (Input.GetButtonDown("Use"))
                {
                    Debug.Log("家に移動");
                    camera.place = OperationTheCamera.PlayerNowPlace.p_house;
                    player.transform.position = Destination.transform.position;
                }
            }
            else if (camera.place == OperationTheCamera.PlayerNowPlace.p_house)
            {
                text.text = "E : 外に出る";

                if (Input.GetButtonDown("Use"))
                {
                    Debug.Log("外に移動");
                    camera.place = OperationTheCamera.PlayerNowPlace.p_notHouse;
                    player.transform.position = Destination.transform.position;
                }
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            text.enabled = false;
        }
    }
}
