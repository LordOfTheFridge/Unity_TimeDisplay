using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseStorage : MonoBehaviour
{
    private const string TimeColorR = "TimeColorR";
    private const string TimeColorG = "TimeColorG";
    private const string TimeColorB = "TimeColorB";
    private const string TimeColorA = "TimeColorA";

    private const string BackgroundColorR = "BackgroundColorR";
    private const string BackgroundColorG = "BackgroundColorG";
    private const string BackgroundColorB = "BackgroundColorB";
    private const string BackgroundColorA = "BackgroundColorA";

    public Color LoadTimeColor()
    {
        if (
            PlayerPrefs.HasKey(TimeColorR) &&
            PlayerPrefs.HasKey(TimeColorG) &&
            PlayerPrefs.HasKey(TimeColorB) &&
            PlayerPrefs.HasKey(TimeColorA)
        ) {
            return new Color(PlayerPrefs.GetFloat(TimeColorR), PlayerPrefs.GetFloat(TimeColorG), PlayerPrefs.GetFloat(TimeColorB), PlayerPrefs.GetFloat(TimeColorA));
        } else {
            return Color.white;
        }
    }

    public Color LoadBackgroundColor()
    {
        if (
            PlayerPrefs.HasKey(BackgroundColorR) &&
            PlayerPrefs.HasKey(BackgroundColorG) &&
            PlayerPrefs.HasKey(BackgroundColorB) &&
            PlayerPrefs.HasKey(BackgroundColorA)
        ) {
            return new Color(PlayerPrefs.GetFloat(BackgroundColorR), PlayerPrefs.GetFloat(BackgroundColorG), PlayerPrefs.GetFloat(BackgroundColorB), PlayerPrefs.GetFloat(BackgroundColorA));
        } else {
            return Color.black;
        }
    }

    public void SaveTimeColor(Color color)
    {
        PlayerPrefs.SetFloat(TimeColorR, color.r);
        PlayerPrefs.SetFloat(TimeColorG, color.g);
        PlayerPrefs.SetFloat(TimeColorB, color.b);
        PlayerPrefs.SetFloat(TimeColorA, color.a);
    }

    public void SaveBackgroundColor(Color color)
    {
        PlayerPrefs.SetFloat(BackgroundColorR, color.r);
        PlayerPrefs.SetFloat(BackgroundColorG, color.g);
        PlayerPrefs.SetFloat(BackgroundColorB, color.b);
        PlayerPrefs.SetFloat(BackgroundColorA, color.a);
    }
}
