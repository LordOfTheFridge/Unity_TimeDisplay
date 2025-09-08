using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [SerializeField] Camera Camera;
    [SerializeField] TMP_Text TextTime;
    [SerializeField] Button ButtonExit;
    [SerializeField] Button ButtonSettings;
    [SerializeField] GameObject PanelSettings;

    [Header("UI")]
    [SerializeField] UISettingsMenu SettingsMenu;

    [Header("Database")]
    [SerializeField] DatabaseStorage Database;

    private Color TimeColorOnStart;
    private Color BackgroundColorOnStart;


    void Start()
    {
        ButtonExit.onClick.AddListener(OnClickButtonExit);
        ButtonSettings.onClick.AddListener(OnClickButtonSettings);

        SettingsMenu.TimeColorPicked += OnTimeColorPicked;
        SettingsMenu.BackgroundColorPicked += OnBackgroundColorPicked;

        TextTime.color = Database.LoadTimeColor();
        TimeColorOnStart = TextTime.color;
        Camera.backgroundColor = Database.LoadBackgroundColor();
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
            Database.SaveTimeColor(TextTime.color);
        }

        if (
            Camera.backgroundColor.r != BackgroundColorOnStart.r ||
            Camera.backgroundColor.g != BackgroundColorOnStart.g ||
            Camera.backgroundColor.b != BackgroundColorOnStart.b ||
            Camera.backgroundColor.a != BackgroundColorOnStart.a
        ) {
            Database.SaveBackgroundColor(Camera.backgroundColor);
        }

        Application.Quit();
    }

    private void OnTimeColorPicked(Color color)
    {
        TextTime.color = color;
    }

    private void OnBackgroundColorPicked(Color color)
    {
        Camera.backgroundColor = color;
    }

    private void OnClickButtonSettings()
    {
        PanelSettings.SetActive(!PanelSettings.activeSelf);
    }

    void OnDestroy()
    {
        ButtonExit.onClick.RemoveListener(OnClickButtonExit);
        ButtonSettings.onClick.RemoveListener(OnClickButtonSettings);

        SettingsMenu.TimeColorPicked -= OnTimeColorPicked;
        SettingsMenu.BackgroundColorPicked -= OnBackgroundColorPicked;
    }
}
