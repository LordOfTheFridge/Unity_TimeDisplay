using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsMenu : MonoBehaviour
{
    private enum EditMode
    {
        None,
        TimeColor,
        BackgroundColor
    }

    public Action<Color> TimeColorPicked;
    public Action<Color> BackgroundColorPicked;

    [SerializeField] Button ButtonTimeColor;
    [SerializeField] Button ButtonBackgroundColor;
    
    [Header("ColorPicker")]
    [SerializeField] FlexibleColorPicker ColorPicker;
    private GameObject ColorPickerObject;

    private EditMode editMode;

    void Start()
    {
        ButtonTimeColor.onClick.AddListener(OnClickButtonTimeColor);
        ButtonBackgroundColor.onClick.AddListener(OnClickButtonBackgroundColor);
        ColorPicker.onColorChange.AddListener(OnColorChange);

        ColorPickerObject = ColorPicker.gameObject;
    }

    void OnDisable()
    {
        ColorPickerObject.SetActive(false);
        editMode = EditMode.None;
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
        switch (editMode) {
            case EditMode.TimeColor:
                TimeColorPicked?.Invoke(color);
                break;
            case EditMode.BackgroundColor:
                BackgroundColorPicked?.Invoke(color);
                break;
            case EditMode.None:
                return;
        }
    }

    void OnDestroy()
    {
        ButtonTimeColor.onClick.RemoveListener(OnClickButtonTimeColor);
        ButtonBackgroundColor.onClick.RemoveListener(OnClickButtonBackgroundColor);
        ColorPicker.onColorChange.RemoveListener(OnColorChange);
    }
}
