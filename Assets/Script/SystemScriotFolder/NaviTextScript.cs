using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NaviTextScript : MonoBehaviour
{
    List<GameObject> gobrins = new List<GameObject>();
    List<GameObject> trolls = new List<GameObject>();

    [SerializeField] Text naviText;
    private void Start()
    {
        naviText.text = "討伐目標";
    }
    private void Update()
    {
        if (gobrins.Count == 0 && trolls.Count == 0)
        {
            GameClearShow();
        }
    }
    public void AddGameObject(GameObject gameObject)
    {
        if (gameObject.name == "Gobrin")
        {
            gobrins.Add(gameObject);
            naviText.text = "討伐対象" + "\n" + "ゴブリン : " + gobrins.Count.ToString() + " 体\n" + "トロール : " + trolls.Count.ToString() + " 体";
            Debug.Log("追加");
        }
        else if (gameObject.name == "Troll")
        {
            trolls.Add(gameObject);
            naviText.text = "討伐対象" + "\n" + "ゴブリン : " + gobrins.Count.ToString() + " 体\n" + "トロール : " + trolls.Count.ToString() + " 体";
        }
    }
    public void RemoveGameObject(GameObject gameObject)
    {
        if (gameObject.name == "Gobrin")
        {
            gobrins.Remove(gameObject);
            naviText.text = "討伐対象" + "\n" + "ゴブリン : " + gobrins.Count.ToString() + " 体\n" + "トロール : " + trolls.Count.ToString() + " 体";
        }
        else if (gameObject.name == "Troll")
        {
            trolls.Remove(gameObject);
            naviText.text = "討伐対象" + "\n" + "ゴブリン : " + gobrins.Count.ToString() + " 体\n" + "トロール : " + trolls.Count.ToString() + " 体";
        }
    }
    void GameClearShow()
    {
        naviText.color = Color.green;
        naviText.text = "MissionComplete!!";
    }
}
