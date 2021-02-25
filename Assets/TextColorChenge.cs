using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChenge : MonoBehaviour
{
    public void ColorChengeRed(Text text)
    {
        text.color = Color.red;
    }
    public void ColorChengeBlue(Text text)
    {
        text.color = Color.blue;
    }
    public void ColorChangeGreen(Text text)
    {
        text.color = Color.green;
    }
    public void ColorChangeYellow(Text text)
    {
        text.color = Color.yellow;
    }
    public void ColorChangeBlack(Text text)
    {
        text.color = Color.black;
    }
    public void ColorChangeWhite(Text text)
    {
        text.color = Color.white;
    }
}
