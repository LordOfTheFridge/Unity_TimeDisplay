using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    [SerializeField] TMP_Text TextTime;
    [SerializeField] Button ButtonExit;

    void Start()
    {
        ButtonExit.onClick.AddListener(OnClickButtonExit);
    }

    void FixedUpdate()
    {
        TextTime.text = DateTime.Now.ToString("hh:mm");

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
        Application.Quit();
    }

    void OnDestroy()
    {
        ButtonExit.onClick.RemoveListener(OnClickButtonExit);
    }
}
