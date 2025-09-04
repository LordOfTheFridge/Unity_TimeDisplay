using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// TODO: Refactoring
public class MainScript : MonoBehaviour
{
    [SerializeField] Camera Camera;
    [SerializeField] TMP_Text TextTime;
    [SerializeField] Button ButtonExit;
    [SerializeField] Button ButtonSettings;
    [SerializeField] GameObject PanelSettings;

    [Header("SettingsMenu")]
    [SerializeField] Button ButtonTimeColor;
    [SerializeField] Button ButtonBackgroundColor;
    private enum EditMode
    {
        None,
        TimeColor,
        BackgroundColor
    }
    private EditMode editMode;

    [Header("ColorPicker")]
    [SerializeField] FlexibleColorPicker ColorPicker;
    private GameObject ColorPickerObject;

    // Data
    private const string TimeColorR = "TimeColorR";
    private const string TimeColorG = "TimeColorG";
    private const string TimeColorB = "TimeColorB";
    private const string TimeColorA = "TimeColorA";

    private const string BackgroundColorR = "BackgroundColorR";
    private const string BackgroundColorG = "BackgroundColorG";
    private const string BackgroundColorB = "BackgroundColorB";
    private const string BackgroundColorA = "BackgroundColorA";

    private Color TimeColorOnStart;
    private Color BackgroundColorOnStart;


    void Start()
    {
        ButtonExit.onClick.AddListener(OnClickButtonExit);
        ButtonSettings.onClick.AddListener(OnClickButtonSettings);

        ButtonTimeColor.onClick.AddListener(OnClickButtonTimeColor);
        ButtonBackgroundColor.onClick.AddListener(OnClickButtonBackgroundColor);
        ColorPicker.onColorChange.AddListener(OnColorChange);

        ColorPickerObject = ColorPicker.gameObject;

        LoadTimeColor();
        TimeColorOnStart = TextTime.color;
        LoadBackgroundColor();
        BackgroundColorOnStart = Camera.backgroundColor;
    }

    void FixedUpdate()
    {
        TextTime.text = DateTime.Now.ToString("HH:mm");

        if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitApplication();
        }
    }

    private void OnClickButtonExit()
    {
        QuitApplication();
    }

    private void QuitApplication()
    {
        if(
            TextTime.color.r != TimeColorOnStart.r ||
            TextTime.color.g != TimeColorOnStart.g ||
            TextTime.color.b != TimeColorOnStart.b ||
            TextTime.color.a != TimeColorOnStart.a
        ) {
            SaveTimeColor();
        }

        if (
            Camera.backgroundColor.r != BackgroundColorOnStart.r ||
            Camera.backgroundColor.g != BackgroundColorOnStart.g ||
            Camera.backgroundColor.b != BackgroundColorOnStart.b ||
            Camera.backgroundColor.a != BackgroundColorOnStart.a
        ) {
            SaveBackgroundColor();
        }

        Application.Quit();
    }

    private void OnClickButtonSettings()
    {
        PanelSettings.SetActive(!PanelSettings.activeSelf);
        if (ColorPickerObject.activeSelf) {
            ColorPickerObject.SetActive(false);

            editMode = EditMode.None;
        }
    }

    private void OnClickButtonTimeColor()
    {
        editMode = EditMode.TimeColor;
        ColorPickerObject.SetActive(true);
    }

    private void OnClickButtonBackgroundColor()
    {
        editMode = EditMode.BackgroundColor;
        ColorPickerObject.SetActive(true);
    }

    private void OnColorChange(Color color)
    {
        if(editMode == EditMode.TimeColor) {
            TextTime.color = color;
        }
        if(editMode == EditMode.BackgroundColor) {
            Camera.backgroundColor = color;
        }
    }

    private void LoadTimeColor()
    {
        if (PlayerPrefs.HasKey(TimeColorA)) {
            TextTime.color = new Color(PlayerPrefs.GetFloat(TimeColorR), PlayerPrefs.GetFloat(TimeColorG), PlayerPrefs.GetFloat(TimeColorB), PlayerPrefs.GetFloat(TimeColorA));
        }
    }

    private void LoadBackgroundColor()
    {
        if (PlayerPrefs.HasKey(BackgroundColorA)) {
            Camera.backgroundColor = new Color(PlayerPrefs.GetFloat(BackgroundColorR), PlayerPrefs.GetFloat(BackgroundColorG), PlayerPrefs.GetFloat(BackgroundColorB), PlayerPrefs.GetFloat(BackgroundColorA));
        }
    }

    private void SaveTimeColor()
    {
        PlayerPrefs.SetFloat(TimeColorR, TextTime.color.r);
        PlayerPrefs.SetFloat(TimeColorG, TextTime.color.g);
        PlayerPrefs.SetFloat(TimeColorB, TextTime.color.b);
        PlayerPrefs.SetFloat(TimeColorA, TextTime.color.a);
    }

    private void SaveBackgroundColor()
    {
        PlayerPrefs.SetFloat(BackgroundColorR, Camera.backgroundColor.r);
        PlayerPrefs.SetFloat(BackgroundColorG, Camera.backgroundColor.g);
        PlayerPrefs.SetFloat(BackgroundColorB, Camera.backgroundColor.b);
        PlayerPrefs.SetFloat(BackgroundColorA, Camera.backgroundColor.a);
    }

    void OnDestroy()
    {
        ButtonExit.onClick.RemoveListener(OnClickButtonExit);
        ButtonSettings.onClick.RemoveListener(OnClickButtonSettings);

        ButtonTimeColor.onClick.RemoveListener(OnClickButtonTimeColor);
        ButtonBackgroundColor.onClick.RemoveListener(OnClickButtonBackgroundColor);
        ColorPicker.onColorChange.RemoveListener(OnColorChange);
    }
}
