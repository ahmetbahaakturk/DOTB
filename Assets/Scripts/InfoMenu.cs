using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMenu : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    void SetText(string text_content) {
        text.text = text_content;
    }
}
