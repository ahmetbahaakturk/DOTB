using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnterScript : MonoBehaviour
{
    GameObject choices_list;

    void Start()
    {
        choices_list = GameObject.Find("ChoicesMenu");
        choices_list.SetActive(true);
        Button[] buttons = FindObjectsOfType(typeof(Button)) as Button[];

        foreach (Button button in buttons) {
            button.onClick.AddListener(delegate{clicked(button);});
        }

        choices_list.SetActive(false);
    }

    void clicked(Button button) {
        if (button.name == "StoryModeButton") {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }

        if (button.name == "FreeModeButton") {  
            choices_list.SetActive(true);
        }

        if (button.transform.parent.name == "Square") {
            SceneManager.LoadScene(button.name + "free", LoadSceneMode.Single);
        }

        if (button.name == "CloseButton") {
            choices_list.SetActive(false);
        }

        if (button.name == "ExitButton") {
            Application.Quit();
        }
    }
}

