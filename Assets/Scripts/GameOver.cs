using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private AudioSource[] allAudioSources;
    private AudioSource source;
    public Scene last_scene;

    void Start()
    {
        Button[] buttons = FindObjectsOfType(typeof(Button)) as Button[];
        buttons[0].onClick.AddListener(delegate{clicked(buttons[0]);});
        buttons[1].onClick.AddListener(delegate{clicked(buttons[1]);});

        Scene[] scenes = SceneManager.GetAllScenes();
        last_scene = scenes[0];
        print(last_scene.name);
        print(last_scene.buildIndex);

        Time.timeScale = 0;
        StopAllAudio();
        if (last_scene.buildIndex != 4) {
            source = GameObject.Find("Musics/Normal_Yanma_Sesi").GetComponent<AudioSource>();
            source.Play();
        } else if (last_scene.buildIndex == 10 || last_scene.buildIndex == 4){
            GameObject level3_yanma_sesi = GameObject.Find("Musics/RamizDayi_Level3_Yanma_Sesi");
            source = level3_yanma_sesi.GetComponent<AudioSource>();
            source.Play();
        }
    }

    void Update() {
        Time.timeScale = 0;
    }

    void clicked(Button btn) {
        print(btn.gameObject.tag);
        if (btn.gameObject.tag == "go_to_education") {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        } else {
            SceneManager.LoadScene(last_scene.buildIndex, LoadSceneMode.Single);           
        }
    }

    void StopAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
    }
}
